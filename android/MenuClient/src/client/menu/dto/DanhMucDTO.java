package client.menu.dto;

import java.io.Serializable;

public class DanhMucDTO implements Serializable {
	int maDanhMuc;
	int maDanhMucCha;
	
	public int getMaDanhMuc() {
		return maDanhMuc;
	}
	public void setMaDanhMuc(int maDanhMuc) {
		this.maDanhMuc = maDanhMuc;
	}
	public int getMaDanhMucCha() {
		return maDanhMucCha;
	}
	public void setMaDanhMucCha(int maDanhMucCha) {
		this.maDanhMucCha = maDanhMucCha;
	}	
	
}
