﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FoodGalleryItemViewModel>" %>
<%@ Import Namespace = "LocalServerWeb.ViewModels" %>
<%@ Import Namespace = "LocalServerWeb.Resources.Views.FoodCategory" %>

<div id="food_gallery_item">
    <table>
        <tr>
        <td>
            <img src =" <%: Model.HinhAnh %> "  alt="food images"/>
        </td>
        </tr>

        <tr>
        <td>
            <%: Model.TenMonAn %>
        </td>
        </tr>

        <tr>
        <td>
            <%: Model.DonGia.ToString() %>
            &nbsp;/&nbsp;
            <%: Model.TenDonViTinhMacDinh %>
        </td>
        </tr>
        <tr>
        <td>
            <%: Html.ActionLink(FoodCategoryString.Detail, "Food", "FoodCategory", new {id=Model.MaMonAn}, "") %>
        </td>
        </tr>
    </table>
</div>
