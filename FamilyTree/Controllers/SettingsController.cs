using System.Web.Mvc;
using FamilyTree.Models;
using FamilyTree.Backend;

namespace FamilyTree.Controllers
{
    /// <summary>
    /// School Dismissal Settings defaults to a single record.  So no Create or Delete, just Read, and Update
    /// </summary>

    public class SettingsController : BaseController
    {
        // The Backend Data source
        private SettingsBackend SettingsBackend = DataSourceBackend.Instance.SettingsBackend;

        /// <summary>
        /// Read information on a single Settings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Settings/Details/5
        public ActionResult Read(string id = null)
        {
            var myData = SettingsBackend.Read(id);
            if (myData == null)
            {
                // If no ID is passed in, get the first one.
                if (id == null)
                {
                    myData = SettingsBackend.GetDefault();
                }
                if (myData == null)
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(myData);
        }

        /// <summary>
        /// This will show the details of the Settings to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Settings/Edit/5
        public ActionResult Update(string id = null)
        {
            var myData = SettingsBackend.Read(id);
            if (myData == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(myData);
        }

        /// <summary>
        /// This updates the Settings based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Settings/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=
                                        "Id," +
                                        "Password," +
                                        "SelectedTimeZoneId" +
                                        "")] SettingsModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }

            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", "Home");
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for edit
                return View(data);
            }

            SettingsBackend.Update(data);

            return RedirectToAction("Read", "Settings");
        }
    }
}
