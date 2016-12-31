/**
 * @author Benjamim Chambule <benchambule@gmail.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.bantu
{
    public class BasicSessionProvider: SessionProvider
    {
        private static Dictionary<String, BasicSession> sessions = new Dictionary<string, BasicSession>();
        public BasicSessionProvider()
        {
        }

        public USSDSession<Object> getSession(USSDRequest request)
        {
            BasicSession bSession = new BasicSession();

            if(!sessions.ContainsKey(request.getMSISDN())){
                sessions.Add(request.getMSISDN(), bSession);
            }

            return (USSDSession<Object>) sessions[request.getMSISDN()];
        }
    }
}
