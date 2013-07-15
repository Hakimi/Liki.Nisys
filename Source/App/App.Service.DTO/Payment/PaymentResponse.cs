namespace Liki.App.Service.DTO.Payments
{
    public class PaymentResponse
    {

        #region Property
        public string redirectURL { get; set; }
        public string authorizationID { get; set; }
        #endregion

        #region Constructors
        public PaymentResponse()
        {

        }
        /// <summary>
        ///  Create a new instance of Payment Response
        /// </summary>
        /// <param name="_redirectURL"></param>
        /// <param name="_authorizationID"></param>
        public PaymentResponse(string _redirectURL, string _authorizationID)
        {
            this.redirectURL = _redirectURL;
            this.authorizationID = _authorizationID;
        }
        #endregion


    }
}
