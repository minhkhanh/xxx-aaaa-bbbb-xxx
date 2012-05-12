﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="LocalServerWeb.Resources.Views.Kitchen" %>

<form action="" id="form-so-luong-che-bien-xong">
	<label for="so-luong-che-bien"><%:KitchenString.SoLuong%></label>
	<select name="soLuongCheBienXong" id="so-luong-che-bien-xong">
    <% for (int i = 1; i <= (int)ViewData["iSoLuongCheBienXongToiDa"]; i++) {%>
		<option value="<%:i %>"><%:i %></option>
    <%} %>
	</select>            
    <input type="hidden" name="maChiTietOrder" value="<%: Request.QueryString["maChiTietOrder"] %>"/>
</form>

<script type="text/javascript">
	$(function () {
	    var select = $("#so-luong-che-bien-xong");
	    var slider = $("<div id='slider'></div>").insertAfter(select).slider({
	        min: 1,
	        max: <%: (int)ViewData["iSoLuongCheBienXongToiDa"] %>,
	        range: "min",
	        value: select[0].selectedIndex + 1,
	        slide: function (event, ui) {
	            select[0].selectedIndex = ui.value - 1;
	        }
	    });
	    $("#so-luong-che-bien-xong").change(function () {
	        slider.slider("value", this.selectedIndex + 1);
	    });
	});
</script>