  public class PrivacyPolicyApiController : ApiController 
    {
        private IPrivacyPolicy _privacyPolicy = null;
        private IUserService _userService = null;
        public PrivacyPolicyApiController(IPrivacyPolicy privacyPolicyService, IUserService userService)
        {
            _privacyPolicy = privacyPolicyService;
            _userService = userService;
        }
		
		[Route("{id:int}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {

            ItemResponse<PrivacyPolicy> response = new ItemResponse<PrivacyPolicy>();

            string currentUserId = _userService.GetCurrentUserId();

            response.Item = _privacyPolicy.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
		
		[Route("{id:int}"), HttpPut]
		 public HttpResponseMessage Update(PrivacyPolicyUpdateRequest model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();

            model.ModifiedBy = _userService.GetCurrentUserId(); 
			
            _privacyPolicy.Update(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
