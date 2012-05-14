﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LocalServerBUS;
using LocalServerWeb.Codes;
using LocalServerWeb.Resources.Views.AdminPromotion;
using LocalServerWeb.Resources.Views.Shared;
using LocalServerDTO;
using LocalServerWeb.ViewModels;

namespace LocalServerWeb.Controllers
{
    public class AdminPromotionController : BaseController
    {
        public ActionResult Index()
        {
            SharedCode.FillAdminMainMenu(ViewData, 3, 2);
            ViewData["listKhuyenMai"] = KhuyenMaiBUS.LayDanhSachKhuyenMai();
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                TempData["error"] = SharedString.InputWrong;
                return RedirectToAction("Index", "Error");
            }

            KhuyenMai khuyenMai = KhuyenMaiBUS.LayKhuyenMai(id ?? 0);
            if (khuyenMai == null)
            {
                TempData["errorNotFound"] = AdminPromotionString.ErrorPromotionNotFound;
                return RedirectToAction("Index", "Error");
            }

            if (!KhuyenMaiBUS.Xoa(khuyenMai.MaKhuyenMai))
            {
                TempData["errorCannotDelete"] = AdminPromotionString.ErrorCannotDelete;
            }
            else
            {
                TempData["infoDeleteSuccess"] = AdminPromotionString.InfoDeleteSuccess;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            SharedCode.FillAdminMainMenu(ViewData, 3, 6);
            if (TempData["checkDic"] == null)
            {
                //TempData.Clear();
                TempData["checkDic"] = new Dictionary<string, string>();
            }

            // De tien su dung, pre populate voi ngay hien tai
            DateTime thoiDiemHienTai = DateTime.Now;
            TempData["ngayBatDau"] = thoiDiemHienTai.Day;
            TempData["thangBatDau"] = thoiDiemHienTai.Month;
            TempData["namBatDau"] = thoiDiemHienTai.Year;

            // ngay Ket thuc la ngay mai
            thoiDiemHienTai = thoiDiemHienTai.AddDays(1);
            TempData["ngayKetThuc"] = thoiDiemHienTai.Day;
            TempData["thangKetThuc"] = thoiDiemHienTai.Month;
            TempData["namKetThuc"] = thoiDiemHienTai.Year;

            return View();
        }

        [HttpPost]
        public ActionResult Add(string tenKhuyenMai, string moTa, int hinhThucGiam, float? giaTri, int ngayBatDau, int thangBatDau, int namBatDau, 
                                int ngayKetThuc, int thangKetThuc, int namKetThuc)
        {
            TempData["tenKhuyenMai"] = tenKhuyenMai;
            TempData["moTa"] = moTa;
            TempData["hinhThucGiam"] = hinhThucGiam;
            TempData["giaTri"] = giaTri;
            TempData["ngayBatDau"] = ngayBatDau;
            TempData["thangBatDau"] = thangBatDau;
            TempData["namBatDau"] = namBatDau;
            TempData["ngayKetThuc"] = ngayKetThuc;
            TempData["thangKetThuc"] = thangKetThuc;
            TempData["namKetThuc"] = namKetThuc;

            var checkDic = new Dictionary<string, string>();

            bool bCheckOk = true;

            // Kiem tra ten Khuyen mai
            if (tenKhuyenMai == null || tenKhuyenMai.Trim().Length < 1)
            {
                bCheckOk = false;
                checkDic.Add("tenKhuyenMai", SharedString.InputWrong);
            }

            // Kiem tra Gia tri co nhap chua
            if (giaTri == null)
            {
                bCheckOk = false;
                checkDic.Add("giaTri", SharedString.InputWrong);
            }

            // hinhThucGiam 
            // 0: giaTriGiam
            // 1: tiLeGiam
            switch (hinhThucGiam)
            {
                case 0:
                    if (giaTri <= 0)
                    {
                        bCheckOk = false;
                        checkDic.Add("giaTri", SharedString.InputWrong);
                    }
                    break;
                case 1:
                    if (giaTri <= 0 || giaTri > 100)
                    {
                        bCheckOk = false;
                        checkDic.Add("giaTri", SharedString.InputWrong);
                    }
                    break;
            }

            // Kiem tra thoi diem bat dau
            DateTime thoiDiemBatDau = DateTime.Now;
            try
            {
                thoiDiemBatDau = new DateTime(namBatDau, thangBatDau, ngayBatDau);
            }
            catch (Exception)
            {
                bCheckOk = false;
                checkDic.Add("thoiDiem", AdminPromotionString.ErrorDateWrong);
            }

            // Kiem tra thoi diem ket thuc
            DateTime thoiDiemKetThuc = DateTime.Now;
            try
            {
                thoiDiemKetThuc = new DateTime(namKetThuc, thangKetThuc, ngayKetThuc);
            }
            catch (Exception)
            {
                bCheckOk = false;
                checkDic.Add("thoiDiem", AdminPromotionString.ErrorDateWrong);
            }


            // Kiem tra Thoi diem bat dau > Thoi diem ket thuc ?
            if (DateTime.Compare(thoiDiemKetThuc, thoiDiemBatDau) <= 0)
            {
                bCheckOk = false;
                checkDic.Add("thoiDiemKetThucSau", AdminPromotionString.ErrorEndDateAfter);
            }

            if (bCheckOk)
            {
                try
                {
                    KhuyenMai khuyenMai = new KhuyenMai();
                    khuyenMai.TenKhuyenMai = tenKhuyenMai;
                    khuyenMai.MoTaKhuyenMai = moTa;
                    khuyenMai.BatDau = thoiDiemBatDau;
                    khuyenMai.KetThuc = thoiDiemKetThuc;

                    if (hinhThucGiam == 0)
                    {
                        khuyenMai.GiaGiam = giaTri??0;
                        khuyenMai.TiLeGiam = 0;
                    }
                    else if (hinhThucGiam == 1)
                    {
                        khuyenMai.GiaGiam = 0;
                        khuyenMai.TiLeGiam = giaTri??0;
                    }

                    // Luon luon tao them Khuyen Mai Hoa Don voi gia tri ap dung = 0
                    if (KhuyenMaiBUS.Them(khuyenMai))
                    {
                        TempData["infoAddSuccess"] = AdminPromotionString.InfoAddSuccess;
                        return RedirectToAction("Index", "AdminPromotion");
                    }
                    else
                    {
                        TempData["errorCannotAdd"] = AdminPromotionString.ErrorCannotAdd;
                    }

                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.StackTrace);
                }
            }

            TempData["checkDic"] = checkDic;
            return RedirectToAction("Add");

        }

        public ActionResult Edit(int? id)
        {
            SharedCode.FillAdminMainMenu(ViewData, 3, 6);
            if (TempData["checkDic"] == null)
            {
                //TempData.Clear();
                TempData["checkDic"] = new Dictionary<string, string>();
            }

            if (id == null || id <= 0)
            {
                TempData["error"] = SharedString.InputWrong;
                return RedirectToAction("Index", "Error");
            }

            KhuyenMai khuyenMai = KhuyenMaiBUS.LayKhuyenMai(id ?? 0);
            if (khuyenMai == null)
            {
                TempData["errorNotFound"] = AdminPromotionString.ErrorPromotionNotFound;
                return RedirectToAction("Index", "Error");
            }
            else
            {
                TempData["tenKhuyenMai"] = khuyenMai.TenKhuyenMai;
                TempData["moTa"] = khuyenMai.MoTaKhuyenMai;
                TempData["hinhThucGiam"] = (khuyenMai.GiaGiam != 0) ? 0 : 1;
                TempData["giaTri"] = (khuyenMai.GiaGiam != 0) ? khuyenMai.GiaGiam : khuyenMai.TiLeGiam;


                // De tien su dung, pre populate voi ngay hien tai
                DateTime thoiDiemHienTai = DateTime.Now;
                TempData["ngayBatDau"] = thoiDiemHienTai.Day;
                TempData["thangBatDau"] = thoiDiemHienTai.Month;
                TempData["namBatDau"] = thoiDiemHienTai.Year;

                // ngay Ket thuc la ngay mai
                thoiDiemHienTai = thoiDiemHienTai.AddDays(1);
                TempData["ngayKetThuc"] = thoiDiemHienTai.Day;
                TempData["thangKetThuc"] = thoiDiemHienTai.Month;
                TempData["namKetThuc"] = thoiDiemHienTai.Year;
            }

            

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int maKhuyenMai, string tenKhuyenMai, string moTa, int hinhThucGiam, float? giaTri, int ngayBatDau, int thangBatDau, int namBatDau,
                                int ngayKetThuc, int thangKetThuc, int namKetThuc)
        {
            TempData["tenKhuyenMai"] = tenKhuyenMai;
            TempData["moTa"] = moTa;
            TempData["hinhThucGiam"] = hinhThucGiam;
            TempData["giaTri"] = giaTri;
            TempData["ngayBatDau"] = ngayBatDau;
            TempData["thangBatDau"] = thangBatDau;
            TempData["namBatDau"] = namBatDau;
            TempData["ngayKetThuc"] = ngayKetThuc;
            TempData["thangKetThuc"] = thangKetThuc;
            TempData["namKetThuc"] = namKetThuc;

            var checkDic = new Dictionary<string, string>();

            bool bCheckOk = true;

            // Kiem tra ten Khuyen mai
            if (tenKhuyenMai == null || tenKhuyenMai.Trim().Length < 1)
            {
                bCheckOk = false;
                checkDic.Add("tenKhuyenMai", SharedString.InputWrong);
            }

            // Kiem tra Gia tri co nhap chua
            if (giaTri == null)
            {
                bCheckOk = false;
                checkDic.Add("giaTri", SharedString.InputWrong);
            }

            // hinhThucGiam 
            // 0: giaTriGiam
            // 1: tiLeGiam
            switch (hinhThucGiam)
            {
                case 0:
                    if (giaTri <= 0)
                    {
                        bCheckOk = false;
                        checkDic.Add("giaTri", SharedString.InputWrong);
                    }
                    break;
                case 1:
                    if (giaTri <= 0 || giaTri > 100)
                    {
                        bCheckOk = false;
                        checkDic.Add("giaTri", SharedString.InputWrong);
                    }
                    break;
            }

            // Kiem tra thoi diem bat dau
            DateTime thoiDiemBatDau = DateTime.Now;
            try
            {
                thoiDiemBatDau = new DateTime(namBatDau, thangBatDau, ngayBatDau);
            }
            catch (Exception)
            {
                bCheckOk = false;
                checkDic.Add("thoiDiem", AdminPromotionString.ErrorDateWrong);
            }

            // Kiem tra thoi diem ket thuc
            DateTime thoiDiemKetThuc = DateTime.Now;
            try
            {
                thoiDiemKetThuc = new DateTime(namKetThuc, thangKetThuc, ngayKetThuc);
            }
            catch (Exception)
            {
                bCheckOk = false;
                checkDic.Add("thoiDiem", AdminPromotionString.ErrorDateWrong);
            }


            // Kiem tra Thoi diem bat dau > Thoi diem ket thuc ?
            if (DateTime.Compare(thoiDiemKetThuc, thoiDiemBatDau) <= 0)
            {
                bCheckOk = false;
                checkDic.Add("thoiDiemKetThucSau", AdminPromotionString.ErrorEndDateAfter);
            }

            if (bCheckOk)
            {
                try
                {
                    KhuyenMai khuyenMai = KhuyenMaiBUS.LayKhuyenMai(maKhuyenMai);
                    khuyenMai.TenKhuyenMai = tenKhuyenMai;
                    khuyenMai.MoTaKhuyenMai = moTa;
                    khuyenMai.BatDau = thoiDiemBatDau;
                    khuyenMai.KetThuc = thoiDiemKetThuc;

                    if (hinhThucGiam == 0)
                    {
                        khuyenMai.GiaGiam = giaTri ?? 0;
                        khuyenMai.TiLeGiam = 0;
                    }
                    else if (hinhThucGiam == 1)
                    {
                        khuyenMai.GiaGiam = 0;
                        khuyenMai.TiLeGiam = giaTri ?? 0;
                    }

                    // Luon luon tao them Khuyen Mai Hoa Don voi gia tri ap dung = 0
                    if (KhuyenMaiBUS.CapNhat(khuyenMai))
                    {
                        TempData["infoEditSuccess"] = AdminPromotionString.InfoEditSuccess;
                        return RedirectToAction("Index", "AdminPromotion");
                    }
                    else
                    {
                        TempData["errorCannotEdit"] = AdminPromotionString.ErrorCannotEdit;
                    }

                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.StackTrace);
                }
            }

            TempData["checkDic"] = checkDic;
            return RedirectToAction("Add");

        }
    }
}