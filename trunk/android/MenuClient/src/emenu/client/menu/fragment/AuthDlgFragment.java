package emenu.client.menu.fragment;

import org.apache.http.client.HttpClient;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.DialogFragment;
import android.app.FragmentManager;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import emenu.client.menu.R;
import emenu.client.bus.task.CustomAsyncTask;
import emenu.client.bus.task.CustomAsyncTask.OnPostExecuteListener;
import emenu.client.bus.task.PostLogInTask;
import emenu.client.dao.BanDAO;
import emenu.client.db.dto.BanDTO;
import emenu.client.util.U;

public class AuthDlgFragment extends DialogFragment implements OnClickListener {

    public static final String KEY_ACTION = "key_action";

    private EditText mNameEdit;
    private EditText mPassEdit;
    private int mAction;
    private OnAuthorizedListener mOnAuthorizedListener;
    private PostLogInTask mLogInTask;

    private OnPostExecuteListener<Void, Void, HttpClient> mOnPostLogIn = new OnPostExecuteListener<Void, Void, HttpClient>() {
        @Override
        public void onPostExecute(CustomAsyncTask<Void, Void, HttpClient> task,
                HttpClient result) {
            if (result != null) {
                mOnAuthorizedListener.onAuthorized(result, getArguments(), mAction);
                dismiss();                
            } else {
                U.toastText(getActivity(), R.string.message_auth_failed);
            }
        }
    };

    public interface OnAuthorizedListener {
        void onAuthorized(HttpClient result, Bundle extras, int action);
    }

    public AuthDlgFragment(OnAuthorizedListener listener, int action) {
        mAction = action;
        mOnAuthorizedListener = listener;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
        getDialog().setTitle(getString(R.string.title_dialog_auth));
        getDialog().setCanceledOnTouchOutside(false);

        View layout = inflater.inflate(R.layout.layout_auth_dlg, container, false);

        return layout;
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        getView().findViewById(R.id.btnOK).setOnClickListener(this);;
        getView().findViewById(R.id.btnCancel).setOnClickListener(this);

        mNameEdit = (EditText) getView().findViewById(R.id.editUsername);
        mPassEdit = (EditText) getView().findViewById(R.id.editPassword);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.btnOK:
                U.cancelAsyncTask(mLogInTask);

                String name = mNameEdit.getText().toString();
                String pass = mPassEdit.getText().toString();
                mLogInTask = new PostLogInTask(name, pass);
                mLogInTask.setOnPostExecuteListener(mOnPostLogIn);
                mLogInTask.setWaitingDialog(U.createWaitingDialog(getActivity()));
                mLogInTask.execute();

                break;
            case R.id.btnCancel:
                dismiss();
                break;
        }
    }
}
