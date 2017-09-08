using APIAuthenticationExample.Models;
using System;
using System.Web.Mvc;

namespace APIAuthenticationExample.Controllers {
    public class ProgramController : Controller {
        [HttpGet]
        [ITCAuthorize(RequiredRole = ITCAuthorizeAttribute.UserRoles.RegisteredUser)]
        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        [ITCAuthorize(RequiredRole = ITCAuthorizeAttribute.UserRoles.RegisteredUser)]
        public ActionResult Create(ProgramModel model) {
            model.BikeTypeID = 1;
            model.ProgramCategoryID = 1;
            string createProgramUrl = string.Format("{0}/Programs", Helper.ITCApiServer);
            ITCResponseModel<ProgramModel> r = ServiceRequestor.PutRequest<ITCResponseModel<ProgramModel>>(createProgramUrl, model, new ITCContext().GetAuthenticationTicket(Request));
            if (r.Error != null) {
                throw new Exception(r.Error);
            }
            return View("Create", r.Data);
        }

        [HttpGet]
        [ITCAuthorize(RequiredRole = ITCAuthorizeAttribute.UserRoles.RegisteredUser)]
        public ActionResult Test() {
            ProgramModel program = new ProgramModel() {
                Name = "Anders program",
                BikeTypeID = 2,
                ProgramCategoryID = 5,
                Description = "anders super fede program"
            };
            string createProgramUrl = string.Format("{0}/Programs", Helper.ITCApiServer);
            ITCResponseModel<ProgramModel> r = ServiceRequestor.PutRequest<ITCResponseModel<ProgramModel>>(createProgramUrl, program, new ITCContext().GetAuthenticationTicket(Request));
            if (r.Error != null) {
                Throw(r.Error);
            }
            else {
                if (r.Data == null) {
                    Throw("No program recieved");
                }
                if (!r.Data.Name.Equals(program.Name)) {
                    Throw("Name didn't match");
                }
                if (!r.Data.BikeTypeID.Equals(program.BikeTypeID)) {
                    Throw("BikeTypeID name didn't match");
                }
                if (!r.Data.Description.Equals(program.Description)) {
                    Throw("Description name didn't match");
                }
                if (!r.Data.ProgramCategoryID.Equals(program.ProgramCategoryID)) {
                    Throw("ProgramCategoryID name didn't match");
                }
            }

            SegmentModel segment = new SegmentModel() {
                Name = "Anders SEGMENT",
                BikeTypeID = 2,
                Description = "anders super fede segment",
                CategoryID = 10
            };
            string createSegmentUrl = string.Format("{0}/Segments", Helper.ITCApiServer);
            ITCResponseModel<SegmentModel> r2 = ServiceRequestor.PutRequest<ITCResponseModel<SegmentModel>>(createSegmentUrl, segment, new ITCContext().GetAuthenticationTicket(Request));
            if (r2.Error != null) {
                Throw(r2.Error);
            }
            else {
                if (r2.Data == null) {
                    Throw("No segment recieved");
                }
                if (!r2.Data.Name.Equals(segment.Name)) {
                    Throw("Name didn't match");
                }
                if (!r2.Data.BikeTypeID.Equals(segment.BikeTypeID)) {
                    Throw("BikeTypeID name didn't match");
                }
                if (!r2.Data.Description.Equals(segment.Description)) {
                    Throw("Description name didn't match");
                }
                if (!r2.Data.CategoryID.Equals(segment.CategoryID)) {
                    Throw("CategoryID name didn't match");
                }
             
            }
            EditProgramSegmentsModel model = new EditProgramSegmentsModel() {
                SegmentIDs = new int[]{ r2.Data.SegmentID }
            };
            string setProgramSegmentsUrl = string.Format("{0}/Programs/"+r.Data.ProgramID+"/segments", Helper.ITCApiServer);
            ITCResponseModel<bool> r3 = ServiceRequestor.PutRequest<ITCResponseModel<bool>>(setProgramSegmentsUrl, model, new ITCContext().GetAuthenticationTicket(Request));
            if (r3.Error != null) {
                Throw(r3.Error);
            }

            string createIntervalUrl = string.Format("{0}/segments/{1}/intervals/", Helper.ITCApiServer, r2.Data.SegmentID);
            IntervalModel interval = new IntervalModel() {
                CycleID =1,
                PositionTypeID = 1,
            };
            ITCResponseModel<IntervalModel> r4 = ServiceRequestor.PutRequest<ITCResponseModel<IntervalModel>>(createIntervalUrl, interval, new ITCContext().GetAuthenticationTicket(Request));
            if (r4.Error != null) {
                Throw(r4.Error);
            }
            IntervalModel createdInterval = r4.Data;

            return View();
        }

        private void Throw(string message) {
            throw new Exception(message);
        }
    }
}