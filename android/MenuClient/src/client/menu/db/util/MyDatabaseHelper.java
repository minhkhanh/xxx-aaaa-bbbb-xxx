package client.menu.db.util;

import java.io.InputStream;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import client.menu.R;
import client.menu.util.U;

public class MyDatabaseHelper extends SQLiteOpenHelper {

    private static final String DB_NAME = "ttdt.db";
    private static final int DB_VERSION = 1;

    Context mContext;

    public MyDatabaseHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);

        mContext = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        InputStream stream = mContext.getResources().openRawResource(R.raw.create_db);
        String sqlCreate = U.convertStreamToString(stream);
        db.execSQL(sqlCreate);

        U.logOwnTag("MyDatabaseHelper.onCreate");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        U.logOwnTag("MyDatabaseHelper.onUpgrade");
    }
}
