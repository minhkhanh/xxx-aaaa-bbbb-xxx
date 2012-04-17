﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalServerDTO;

namespace LocalServerDAO
{
    public class ChiTietOrderDAO
    {
        public static ChiTietOrder LayChiTietOrder(int maChiTietOrder)
        {
            var temp = ThucDonDienTu.DataContext.ChiTietOrders.Where(m => m.MaChiTietOrder == maChiTietOrder);
            if (temp.Count() > 0)
            {
                ChiTietOrder ct = temp.First();
                return ct;
            }
            return null;
        }

        public static ChiTietOrder ThemChiTietOrder(ChiTietOrder _chiTietOrder)
        {
            ThucDonDienTu.DataContext.ChiTietOrders.InsertOnSubmit(_chiTietOrder);
            try
            {
                ThucDonDienTu.DataContext.SubmitChanges();
            }
            catch (Exception e)
            {
                _chiTietOrder = null;
            }

            return _chiTietOrder;
        }

        public static bool SuaChiTietOrder(ChiTietOrder _chiTietOrder)
        {
            bool result = false;
            var temp = ThucDonDienTu.DataContext.ChiTietOrders.Where(c => c.MaChiTietOrder == _chiTietOrder.MaChiTietOrder);
            if (temp.Count() > 0)
            {
                ChiTietOrder ct = temp.First();
                ct = _chiTietOrder;
            }

            try
            {
                ThucDonDienTu.DataContext.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }


    }
}
