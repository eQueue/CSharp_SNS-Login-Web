using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_WorkFlow.DB;

namespace Project_WorkFlow.Areas.WorkFlow.Controllers
{
    public class TblUserDatasController : Controller
    {
        private WORKFLOWDB db = new WORKFLOWDB();

        // GET: WorkFlow/TblUserDatas
        public ActionResult Index()
        {
            return View(db.TblUserData.ToList());
        }

        // GET: WorkFlow/TblUserDatas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUserData tblUserData = db.TblUserData.Find(id);
            if (tblUserData == null)
            {
                return HttpNotFound();
            }
            return View(tblUserData);
        }

        // GET: WorkFlow/TblUserDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkFlow/TblUserDatas/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_idx,C_kakaoIdData,C_emailData,C_nickNameData,C_profileData")] TblUserData tblUserData)
        {
            if (ModelState.IsValid)
            {
                db.TblUserData.Add(tblUserData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUserData);
        }

        // GET: WorkFlow/TblUserDatas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUserData tblUserData = db.TblUserData.Find(id);
            if (tblUserData == null)
            {
                return HttpNotFound();
            }
            return View(tblUserData);
        }

        // POST: WorkFlow/TblUserDatas/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하세요. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하세요.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_idx,C_kakaoIdData,C_emailData,C_nickNameData,C_profileData")] TblUserData tblUserData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUserData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUserData);
        }

        // GET: WorkFlow/TblUserDatas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUserData tblUserData = db.TblUserData.Find(id);
            if (tblUserData == null)
            {
                return HttpNotFound();
            }
            return View(tblUserData);
        }

        // POST: WorkFlow/TblUserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TblUserData tblUserData = db.TblUserData.Find(id);
            db.TblUserData.Remove(tblUserData);
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
