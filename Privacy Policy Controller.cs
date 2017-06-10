public class PrivacyPolicyController : AdminBaseController
    {
        [Route("old")] 
        public ActionResult Index() 
        {
            return View();
        }

        [Route("Create")]
        [Route("{id:int}/edit")]
        public ActionResult Manage(int id = 0) 
        {
            vm.Item = id;
            return View(vm);
        }

        [Route] 
        public ActionResult NgIndex()
        {
            return View();
        }

    }