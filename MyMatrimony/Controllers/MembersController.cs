using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMatrimony.Models;

namespace MyMatrimony.Controllers
{
    public class MembersController : Controller
    {
        private MyMatrimonyDBEntities db = new MyMatrimonyDBEntities();

        // GET: Members
        public ActionResult ListMembers()
        {
            #region Filters - City Model
            List<CheckBoxModel> cityModel = new List<CheckBoxModel>();
            foreach (var city in db.tblCityMasters.ToList())
            {
                cityModel.Add(new CheckBoxModel() { Text = city.CityName, Value = city.Id.ToString(), isChecked = true });
            }
            ViewBag.Cities = cityModel;
            #endregion
            
            #region Filters - Religion Model
            List<CheckBoxModel> religionModel = new List<CheckBoxModel>();
            foreach (var religion in db.tblReligionMasters.ToList())
            {
                religionModel.Add(new CheckBoxModel() { Text = religion.ReligionName, Value = religion.Id.ToString(), isChecked = true });
            }
            ViewBag.Religions = religionModel;

            var tblMembers = db.tblMembers.Include(t => t.tblCasteMaster).Include(t => t.tblCityMaster).Include(t => t.tblGenderMaster).Include(t => t.tblHeightMaster).Include(t => t.tblMotherTongueMaster).Include(t => t.tblReligionMaster).Include(t => t.tblSkinToneMaster).Include(t => t.tblAnnualIncomeMaster).Include(t => t.tblBodyTypeMaster).Include(t => t.tblDietMaster);
            return View(tblMembers.ToList()); 
            #endregion
        }

        /// <summary>
        /// Apply filters if any and send the filtered data back
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListMembers(FormCollection form)
        {
            // Get the city checkbox values
            var selectedCityChkBxIds = form.AllKeys.Where(x => x.StartsWith("chkCity_") && (form[x].Contains("true"))).ToList();
            List<string> selectedCityIds = new List<string>();
            foreach (var cityId in selectedCityChkBxIds)
            {
                selectedCityIds.Add(cityId.Substring(cityId.IndexOf('_') + 1));
            }

            // Form the cities master data to show in city filter
            List<CheckBoxModel> cityModel = new List<CheckBoxModel>();
            foreach (var city in db.tblCityMasters.ToList())
            {
                cityModel.Add(new CheckBoxModel() { Text = city.CityName, Value = city.Id.ToString(), isChecked = selectedCityIds.Contains(city.Id.ToString()) });
            }
            ViewBag.Cities = cityModel;

            var tblMembers = db.tblMembers.Include(t => t.tblCasteMaster).Include(t => t.tblCityMaster).Include(t => t.tblGenderMaster).Include(t => t.tblHeightMaster).Include(t => t.tblMotherTongueMaster).Include(t => t.tblReligionMaster).Include(t => t.tblSkinToneMaster).Include(t => t.tblAnnualIncomeMaster).Include(t => t.tblBodyTypeMaster).Include(t => t.tblDietMaster);
            tblMembers = tblMembers.Where(x => selectedCityIds.Contains(x.CityId.ToString()));
            return View(tblMembers.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMember tblMember = db.tblMembers.Find(id);
            if (tblMember == null)
            {
                return HttpNotFound();
            }
            return View(tblMember);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.CasteId = new SelectList(db.tblCasteMasters, "Id", "CasteName");
            ViewBag.CityId = new SelectList(db.tblCityMasters, "Id", "CityName");
            ViewBag.GenderId = db.tblGenderMasters.ToList();
            ViewBag.HeightId = new SelectList(db.tblHeightMasters, "Id", "Height");
            ViewBag.MotherTongueId = new SelectList(db.tblMotherTongueMasters, "Id", "MotherTongue");
            ViewBag.ReligionId = new SelectList(db.tblReligionMasters, "Id", "ReligionName");
            ViewBag.SkinToneId = new SelectList(db.tblSkinToneMasters, "Id", "SkinTone");
            ViewBag.AnnualIncomeId = new SelectList(db.tblAnnualIncomeMasters, "Id", "AnnualIncome");
            ViewBag.BodyTypeId = new SelectList(db.tblBodyTypeMasters, "Id", "BodyType");
            ViewBag.DietId = new SelectList(db.tblDietMasters, "Id", "Diet");
            ViewBag.ZodiacSignId = new SelectList(db.tblZodiacSigns, "Id", "ZodiacSign");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "", Include = "Id,Email,Password,ConfirmPassword,Name,DateOfBirth,MobileNo,CityId,ReligionId,HeightId,MotherTongueId,CasteId,GenderId,SkinToneId,BodyTypeId,BodyWeight,DietId,Drink,Smoke,Education,AnnualIncomeId,Occupation,ZodiacSignId,Hobbies,AboutMyself")] tblMember tblMember)
        {
            if (ModelState.IsValid)
            {
                db.tblMembers.Add(tblMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CasteId = new SelectList(db.tblCasteMasters, "Id", "CasteName", tblMember.CasteId);
            ViewBag.CityId = new SelectList(db.tblCityMasters, "Id", "CityName", tblMember.CityId);
            ViewBag.GenderId = db.tblGenderMasters.ToList();
            ViewBag.HeightId = new SelectList(db.tblHeightMasters, "Id", "Height", tblMember.HeightId);
            ViewBag.MotherTongueId = new SelectList(db.tblMotherTongueMasters, "Id", "MotherTongue", tblMember.MotherTongueId);
            ViewBag.ReligionId = new SelectList(db.tblReligionMasters, "Id", "ReligionName", tblMember.ReligionId);
            ViewBag.SkinToneId = new SelectList(db.tblSkinToneMasters, "Id", "SkinTone", tblMember.SkinToneId);
            ViewBag.AnnualIncomeId = new SelectList(db.tblAnnualIncomeMasters, "Id", "AnnualIncome", tblMember.AnnualIncomeId);
            ViewBag.BodyTypeId = new SelectList(db.tblBodyTypeMasters, "Id", "BodyType", tblMember.BodyTypeId);
            ViewBag.DietId = new SelectList(db.tblDietMasters, "Id", "Diet", tblMember.DietId);
            ViewBag.ZodiacSignId = new SelectList(db.tblZodiacSigns, "Id", "ZodiacSign");
            return View(tblMember);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMember tblMember = db.tblMembers.Find(id);
            if (tblMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.CasteId = new SelectList(db.tblCasteMasters, "Id", "CasteName", tblMember.CasteId);
            ViewBag.CityId = new SelectList(db.tblCityMasters, "Id", "CityName", tblMember.CityId);
            ViewBag.GenderId = new SelectList(db.tblGenderMasters, "Id", "Gender", tblMember.GenderId);
            ViewBag.HeightId = new SelectList(db.tblHeightMasters, "Id", "Height", tblMember.HeightId);
            ViewBag.MotherTongueId = new SelectList(db.tblMotherTongueMasters, "Id", "MotherTongue", tblMember.MotherTongueId);
            ViewBag.ReligionId = new SelectList(db.tblReligionMasters, "Id", "ReligionName", tblMember.ReligionId);
            ViewBag.SkinToneId = new SelectList(db.tblSkinToneMasters, "Id", "SkinTone", tblMember.SkinToneId);
            ViewBag.AnnualIncomeId = new SelectList(db.tblAnnualIncomeMasters, "Id", "AnnualIncome", tblMember.AnnualIncomeId);
            ViewBag.BodyTypeId = new SelectList(db.tblBodyTypeMasters, "Id", "BodyType", tblMember.BodyTypeId);
            ViewBag.DietId = new SelectList(db.tblDietMasters, "Id", "Diet", tblMember.DietId);
            return View(tblMember);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Name,DateOfBirth,MobileNo,CityId,ReligionId,HeightId,MotherTongueId,CasteId,GenderId,SkinToneId,BodyTypeId,BodyWeight,DietId,Drink,Smoke,Education,AnnualIncomeId,Occupation,Hobbies,AboutMyself")] tblMember tblMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CasteId = new SelectList(db.tblCasteMasters, "Id", "CasteName", tblMember.CasteId);
            ViewBag.CityId = new SelectList(db.tblCityMasters, "Id", "CityName", tblMember.CityId);
            ViewBag.GenderId = new SelectList(db.tblGenderMasters, "Id", "Gender", tblMember.GenderId);
            ViewBag.HeightId = new SelectList(db.tblHeightMasters, "Id", "Height", tblMember.HeightId);
            ViewBag.MotherTongueId = new SelectList(db.tblMotherTongueMasters, "Id", "MotherTongue", tblMember.MotherTongueId);
            ViewBag.ReligionId = new SelectList(db.tblReligionMasters, "Id", "ReligionName", tblMember.ReligionId);
            ViewBag.SkinToneId = new SelectList(db.tblSkinToneMasters, "Id", "SkinTone", tblMember.SkinToneId);
            ViewBag.AnnualIncomeId = new SelectList(db.tblAnnualIncomeMasters, "Id", "AnnualIncome", tblMember.AnnualIncomeId);
            ViewBag.BodyTypeId = new SelectList(db.tblBodyTypeMasters, "Id", "BodyType", tblMember.BodyTypeId);
            ViewBag.DietId = new SelectList(db.tblDietMasters, "Id", "Diet", tblMember.DietId);
            return View(tblMember);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMember tblMember = db.tblMembers.Find(id);
            if (tblMember == null)
            {
                return HttpNotFound();
            }
            return View(tblMember);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMember tblMember = db.tblMembers.Find(id);
            db.tblMembers.Remove(tblMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
