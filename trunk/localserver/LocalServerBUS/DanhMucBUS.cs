﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalServerDAO;
using LocalServerDTO;

namespace LocalServerBUS
{
    public class DanhMucBUS
    {
        public static List<DanhMuc> LayDanhSachDanhMuc()
        {
            return DanhMucDAO.LayDanhSachDanhMuc();
        }

        public static DanhMuc LayDanhMuc(int maDanhMuc)
        {
            return DanhMucDAO.LayDanhMuc(maDanhMuc);
        }

        public static List<DanhMuc> LayDanhSachDanhMucTheoDanhMucCha(int maDanhMucCha)
        {
            return DanhMucDAO.LayDanhSachDanhMucTheoDanhMucCha(maDanhMucCha);
        }

        public static List<DanhMuc> LayDanhSachDanhMucRoot()
        {
            return DanhMucDAO.LayDanhSachDanhMucRoot();
        }

        public static List<DanhMuc> LayDanhSachDanhMucConChauDanhMucCha(int maDanhMucCha)
        {
            List<DanhMuc> dsDanhMuc = DanhMucBUS.LayDanhSachDanhMucTheoDanhMucCha(maDanhMucCha);
            if (dsDanhMuc != null)
            {
                for (int i = 0; i < dsDanhMuc.Count; ++i)
                    dsDanhMuc.AddRange(LayDanhSachDanhMucConChauDanhMucCha(dsDanhMuc[i].MaDanhMuc));
            }
            return dsDanhMuc;
        }

        private List<DanhMuc> DeQuiLayDanhMuc(int maDanhMucCha)
        {
            List<DanhMuc> dsDanhMuc = DanhMucBUS.LayDanhSachDanhMucTheoDanhMucCha(maDanhMucCha);
            if (dsDanhMuc != null)
            {
                for (int i = 0; i < dsDanhMuc.Count; ++i)
                    dsDanhMuc.AddRange(DeQuiLayDanhMuc(dsDanhMuc[i].MaDanhMuc));
            }
            return dsDanhMuc;
        }

        private static List<DanhMuc> LayDanhSachDanhMucLevelThapNhat()
        {
            return DanhMucDAO.LayDanhSachDanhMucLevelThapNhat();
        }

        public static List<DanhMuc> LayDanhSachDanhMucLevelThapNhatTheoNgonNgu(NgonNgu ngonNgu)
        {
            var temp = LayDanhSachDanhMucLevelThapNhat();
            foreach (var danhMuc in temp)
            {
                danhMuc.TenDanhMuc =
                    ChiTietDanhMucDaNgonNguBUS.LayChiTietDanhMucDaNgonNgu(danhMuc.MaDanhMuc, ngonNgu.MaNgonNgu).
                        TenDanhMuc;
            }
            return temp.ToList();
        }

        public static bool Xoa(int maDanhMuc)
        {
            return DanhMucDAO.Xoa(maDanhMuc);
        }

        public static bool Them(DanhMuc danhMuc)
        {
            return DanhMucDAO.Them(danhMuc);
        }

        public static bool CapNhat(DanhMuc danhMuc)
        {
            return DanhMucDAO.CapNhat(danhMuc);
        }


    }
}
