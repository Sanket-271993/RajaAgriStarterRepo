using System.Net;
using System.Net.Http;

namespace RajaAgriApp.Common
{
  
        public class ApiStatusMessage
        {
            public static string CheckStatusCode(HttpResponseMessage responseMessage)
            {
                string messsage = string.Empty;
                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Set logic about unauthorized
                }
                else
                {
                    messsage = SetStatusCodeMessage(responseMessage);
                }


                return messsage;
            }

            /// <summary>
            /// Set error message
            /// </summary>
            /// <param name="responseMessage"></param>
            /// <returns></returns>
            private static string SetStatusCodeMessage(HttpResponseMessage responseMessage)
            {
                if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                {
                    return AppConstant.INVALID_USER;
                }
                else
                {
                    return GetAPIResponseStatusCodeMessage(responseMessage);
                }
            }

            private static string GetAPIResponseStatusCodeMessage(HttpResponseMessage responseMessage)
            {
                string message;
                if (responseMessage != null && responseMessage.StatusCode == HttpStatusCode.ServiceUnavailable
                    || responseMessage.StatusCode == HttpStatusCode.InternalServerError
                    || responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    message = AppConstant.MSG_SERVICE_UNAVAILABLE;
                }
                else
                {
                    message = AppConstant.DEFUAULT_SERVICES_MESSAGE;
                }
                return message;
            }
        }
       
    }

