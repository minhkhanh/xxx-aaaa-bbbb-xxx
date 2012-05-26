package client.menu.app;

import android.content.Context;
import client.menu.db.dao.BanDAO;
import client.menu.db.dao.DanhMucDAO;
import client.menu.db.dao.DonViTinhDAO;
import client.menu.db.dao.HoaDonDAO;
import client.menu.db.dao.KhuVucDAO;
import client.menu.db.dao.MonAnDAO;
import client.menu.db.dao.NgonNguDAO;
import client.menu.db.dao.OrderDAO;
import client.menu.db.util.MyDatabaseHelper;

public final class MyAppRepository {
    
    public static final String LOCAL_SERVER_URL = "http://192.168.1.4/RestService/LocalService.svc/";
//    public static final String LOCAL_SERVER_URL = "http://10.0.2.2:5252/LocalService.svc/";

    private static MyAppRepository mInstance;

    private MyAppRepository(Context context) {
        MyDatabaseHelper dbHelper = new MyDatabaseHelper(context);

        BanDAO.createInstance(dbHelper);
        NgonNguDAO.createInstance(dbHelper);
        DanhMucDAO.createInstance(dbHelper);
        MonAnDAO.createInstance(dbHelper);
        DonViTinhDAO.createInstance(dbHelper);
        OrderDAO.createInstance(dbHelper);
        KhuVucDAO.createInstance(dbHelper);
        HoaDonDAO.createInstance(dbHelper);
    }

    public static final void createInstance(Context context) {
        mInstance = new MyAppRepository(context);
    }

    public static final MyAppRepository getInstance() {
        return mInstance;
    }
}
