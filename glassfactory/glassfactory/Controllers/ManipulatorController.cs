using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using glassfactory.Models;

namespace glassfactory.Controllers
{
    public class ManipulatorController : ApiController
    {
        private Manipulator Manipulator = new Manipulator();

        public string GetManipulatedText(int id)
        {
            Manipulator.BreakIntoSentences(id);
            return "Hello";
        }
    }
}
