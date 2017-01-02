using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace org.bantu.tests
{
    class LoginProcessor: USSDProcessor
    {
        public void process(USSDRequest request, USSDSession<Object> session, USSDResponse response)
        {
            String pin = session["pin"].ToString();
            if (pin.Equals("1234"))
                request.redirectTo("operations", session, response);
            else
                request.redirectTo("recoverPassword", session, response);
        }
    }

    class AmountWindowProcessor : USSDProcessor
    {
        public void process(USSDRequest request, USSDSession<Object> session, USSDResponse response)
        {
            request.redirectTo("requestSubmited", session, response);
        }
    }

    class TransfersAccountMenuItemsProvider : MenuItemsProvider
    {
        public List<MenuItem> getMenuItems(String windowName, USSDRequest request, USSDSession<Object> session)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem { Description = "3400231", TargetWindow = "amountWindow" });
            menuItems.Add(new MenuItem { Description = "171021", TargetWindow = "amountWindow" });

            return menuItems;
        }
    }

    [TestFixture]
    [Author("Ben Chambule", "benchambule@gmail.com")]
    public class BasicApplicationTests
    {
        private const String TEST_BASE_CODE ="*181#";

        private void fillRequest(USSDRequest request)
        {
            request.setMSISDN("+258842538083");
            //TODO: Set more stuff here
        }

        private static USSDApplication getTestApp1()
        {
            USSDApplication application = new BaseUSSDApplication();

            //LoginWindow
            Window loginWindow = new Window("login");
            loginWindow.addMessage(new Message("Please introduce your pin code", "msg1"));
            loginWindow.addMenuItem(new MenuItem { Description = "Forgot password", TargetWindow = "recoverPassword" });
            loginWindow.setInput(new Input { Name = "pin" });
            loginWindow.setUSSDProcessor(new LoginProcessor());

            //RecoverPasswordWindow
            Window recoverPassword = new Window("recoverPassword");
            recoverPassword.addMessage(new Message("Ops! This is not working yet!"));

            //OperationsWindow
            Window operationsWindow = new Window("operations");
            operationsWindow.addMessage(new Message("Please select an operation", "msg2"));
            operationsWindow.addMenuItem(new MenuItem{Description="Transfers", TargetWindow="transfers"});
            operationsWindow.addMenuItem(new MenuItem{Description="Withdrawal", TargetWindow="withdrawal"});

            //TransfersWindow
            Window transfersWindow = new Window("tranfers");
            transfersWindow.addMessage(new Message("Please select the origin account", "msg3"));
            transfersWindow.addMenuItemsProviders(new TransfersAccountMenuItemsProvider());

            //AmountWindow
            Window amountWindow = new Window("amountWindow");
            amountWindow.addMessage(new Message("Please introduce the amount"));
            amountWindow.setInput(new Input{Name="amount", RegExp="[0-9]+", OnErrorTargetWindow="invalidAmount"});
            amountWindow.setUSSDProcessor(new AmountWindowProcessor());

            Window invalidAmountWindow = new Window("invalidAmount");
            invalidAmountWindow.addMessage(new Message("Invalid Amount : {{amount}}. Please try again"));

            Window requestSubmitted = new Window("requestSubmited");
            requestSubmitted.addMessage(new Message("Request Submitted Successfully"));

            application.addWindow(loginWindow);
            application.addWindow(recoverPassword);
            application.addWindow(operationsWindow);
            application.addWindow(transfersWindow);
            application.addWindow(amountWindow);
            application.addWindow(invalidAmountWindow);
            application.addWindow(requestSubmitted);
            application.addWindow(recoverPassword);

            application.setStartupWindowId(loginWindow.getId());
            application.activateBaseCode(TEST_BASE_CODE);

            return application;
        }

        [SetUp]
        public void wipeSession()
        {
            USSDRequest request = getTestApp1().newRequest(TEST_BASE_CODE);

        }

        [Test]
        public void mustRenderLoginWindow()
        {
            USSDRequest request = getTestApp1().newRequest(TEST_BASE_CODE);
            fillRequest(request);
            USSDResponse response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("login", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
        }

        [Test]
        public void mustRenderPasswordRecoverWindow()
        {
            USSDRequest request = getTestApp1().newRequest("1111");
            fillRequest(request);
            USSDApplication app = getTestApp1();
            USSDResponse response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("recoverPassowrd", response.getWindow().getId());
            Assert.AreEqual(ResponseType.MESSAGE, response.getResponseType());
        }

        [Test]
        public void mustRenderOperationsWindow()
        {
            USSDRequest request = getTestApp1().newRequest("1234");
            fillRequest(request);
            USSDResponse response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("operations", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
        }

        [Test]
        public void mustRenderInvalidAmountWindow()
        {
            USSDApplication app = getTestApp1();
            USSDRequest request = app.newRequest("1234");
            fillRequest(request);

            USSDResponse response = BantU.executeRequest(app, request);
            Assert.AreEqual("operations", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
            request = app.newRequest("1");
            fillRequest(request);

            response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("transfers", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
            request = app.newRequest("2");
            fillRequest(request);

            response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("amountWindow", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
            request = app.newRequest("-1000");
            fillRequest(request);

            response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("invalidAmount", response.getWindow().getId());
            Assert.AreEqual(ResponseType.MESSAGE, response.getResponseType());

        }

        [Test]
        public void mustRenderRequestSubmittedWindow()
        {
            USSDApplication app = getTestApp1();
            USSDRequest request = app.newRequest("1234");
            fillRequest(request);

            USSDResponse response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("operations", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
            request = app.newRequest("1");
            fillRequest(request);

            response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("transfers", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
            request = app.newRequest("2");
            fillRequest(request);

            response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("amountWindow", response.getWindow().getId());
            Assert.AreEqual(ResponseType.FORM, response.getResponseType());
            request = app.newRequest("1000");
            fillRequest(request);

            response = BantU.executeRequest(getTestApp1(), request);
            Assert.AreEqual("requestSubmitted", response.getWindow().getId());
            Assert.AreEqual(ResponseType.MESSAGE, response.getResponseType());
        }

        [Test]
        public void windowFilterMustBeInvoked()
        {
            USSDApplication app = new BaseUSSDApplication();
            Window window = new Window("startup");
            window.addMessage(new Message("Welcome, please type something"));
            window.setInput(new Input { Name = "something" });
            app.addWindowFilter(window.getId(), new StartupWindowFirstFilter());
            app.addWindowFilter(window.getId(), new StartupWindowSecondFilter());

            app.addWindow(window);
            app.setStartupWindowId(window.getId());

            USSDRequest request = app.newRequest(TEST_BASE_CODE);
            fillRequest(request);
            USSDResponse response = BantU.executeRequest(app, request);
            Assert.AreEqual("Altered by the second filter", response.getWindow().getMessages()[0]);
        }

        [Test]
        public void globalFilterMustBeInvoked()
        {
            USSDApplication app = new BaseUSSDApplication();
            Window window = new Window("main");
            window.addMessage(new Message("I'm in the main Window"));
            window.setInput(new Input { Name = "something" });

            Window secondWindow = new Window("Second");
            secondWindow.addMessage(new Message("I'm the second window"));


        }
    }

    public class StartupWindowFirstFilter : USSDFilter
    {
        public void doFilter(USSDRequest request, USSDSession<Object> session, USSDResponse response, USSDFilteringChain chain)
        {
            chain.proceed(request, session, response);
            response.getWindow().getMessages()[0].setContent("Added by the first window filter");
        }
    }

    public class StartupWindowSecondFilter : USSDFilter
    {
        public void doFilter(USSDRequest request, USSDSession<Object> session, USSDResponse response, USSDFilteringChain chain)
        {
            chain.proceed(request, session, response);
            response.getWindow().getMessages()[0].setContent("Altered by the second filter");
        }
    }
}
