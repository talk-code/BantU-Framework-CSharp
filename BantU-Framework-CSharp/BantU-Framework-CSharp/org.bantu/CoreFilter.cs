﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace org.bantu
{
    public class CoreFilter: USSDFilter
    {
        public static String BACKWARD_TARGET_WINDOW = "#backward";

        public void doFilter(USSDRequest request, USSDSession<Object> session, USSDResponse response, USSDFilteringChain chain)
        {
            String cWName;
            Window currentWindow;

            cWName = session.getCurrentWindow();
            if (String.IsNullOrEmpty(cWName))
            {
                session.setCurrentWindow(request.getApplication().getStartupWindowId());
                cWName = request.getApplication().getStartupWindowId();
            }

            currentWindow = request.getApplication().getWindow(cWName);

            List<USSDFilter> windowFilters = request.getApplication().getWindowFilters(session.getCurrentWindow());

            if (windowFilters.Count > 0)
            {
                foreach(USSDFilter filter in windowFilters){
                    chain.appendFilter(filter);
                }

                BaseUSSDFilter ussdFilter = new BaseUSSDFilter();
                ussdFilter.proceedProcessing = new BaseUSSDFilter.ProceedProcessing(proceedProcessing);

                chain.appendFilter(ussdFilter);

                chain.proceed(request, session, response);

                session.saveSession();
            }
        }

        private void proceedProcessing(USSDRequest request, USSDSession<object> session, USSDResponse response, String currentWindowName, Window currentWindow)
        {
            if (currentWindow == null)
                throw new WindowNotFoundException(currentWindowName, request, response, session);


        }

        private void getMenuItemsFromProviders(Window window, USSDRequest request, USSDSession<object> session)
        {
            List<MenuItemsProvider> menuItemsProviders = window.getMenuItemsProvider();
            foreach (MenuItemsProvider provider in menuItemsProviders)
            {
                List<MenuItem> menuItems = provider.getMenuItems(window.getId(), request, session);
                foreach (MenuItem menu in menuItems)
                {
                    window.getMenuItems().Add(menu);
                }
            }
        }

        private bool regularExpressionMatches(String regexp, String value, USSDRequest request)
        {
            Regex regex = new Regex(regexp);
            Match match = regex.Match(value);

            return match.Success ? true : false;
        }

        private bool matchInput(Window currentWindow, PostRequest request, USSDSession<Object> session, USSDResponse response)
        {
            String regExp = currentWindow.getInput().RegExp;
           
            String value = request.getInputValue();

            session[currentWindow.getInput().Name] = value;

            if (currentWindow.getInput().RegExp != null)
            {
                bool matches = regularExpressionMatches(regExp, value, request);

                if (!matches)
                {
                    request.redirectTo(currentWindow.getInput().OnErrorTargetWindow, session, response);
                    return false;
                }
            }

            return true;
        }

        private bool matchMenuItemsAndRedirect(Window currentWindow, PostRequest request, USSDSession<Object> session, USSDResponse response)
        {
            foreach (MenuItem menuItem in currentWindow.getMenuItems())
            {
                if(menuItem.Index.Equals(request.getInputValue())){
                    if (currentWindow.getMenuValueName() != null)
                    {
                        session[currentWindow.getMenuValueName()] = menuItem.Value;
                    }

                    if (menuItem.TargetWindow != null)
                    {
                        String windowId = whereToGo(menuItem, request, response, session);
                        request.redirectTo(windowId, session, response);

                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        private String whereToGo(MenuItem menuItem, USSDRequest request, USSDResponse response, USSDSession<Object> session)
        {
            if(menuItem.TargetWindow.Equals(BACKWARD_TARGET_WINDOW)){
                if(session.getPreviousWindow() ==  null){
                    throw new ImpossibleBackwardRedirectException(menuItem, request, response, session);
                }

                return session.getPreviousWindow();
            }

            return menuItem.TargetWindow;
        }
    }
}
