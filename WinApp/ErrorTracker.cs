using System.Collections.Generic;
using System.Windows.Forms;

namespace WinApp
{
    /// <summary>
    /// Error Track.
    /// ref: http://stackoverflow.com/questions/2682136/c-sharp-winforms-errorprovider-control.
    /// </summary>
    public class ErrorTracker : ErrorProvider
    {
        private HashSet<Control> mErrors = new HashSet<Control>();
        private ErrorProvider mProvider;

        public ErrorTracker(ErrorProvider provider)
        {
            this.mProvider = provider;
        }

        public int Count
        {
            get { return this.mErrors.Count; }
        }

        public List<Control> GetControls()
        {
            return this.GetControls(this.ContainerControl);
        }

        public List<Control> GetControls(Control ParentControl)
        {
            List<Control> ret = new List<Control>();

            if (ParentControl is TextBox && string.IsNullOrEmpty(ParentControl.Text))
            {
                ret.Add(ParentControl);
            }

            foreach (Control c in ParentControl.Controls)
            {
                List<Control> child = GetControls(c);
                if (child.Count > 0)
                {
                    ret.AddRange(child);
                }
            }

            return ret;
        }

        public bool ValidationControls(Control parentControl)
        {
            bool result = true;
            List<Control> ret = this.GetControls(parentControl);
            foreach (Control control in ret)
            {
                this.SetAndCountError(control, "Please fill the required field");
                result = false;
            }

            return result;
        }

        public void ValidationControl(Control control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                this.mProvider.SetError(control, "Please fill the required field");
                control.Focus();
            }
            else
            {
                this.mProvider.SetError(control, string.Empty);
            }
        }

        public void SetAndCountError(Control control, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                this.mErrors.Remove(control);
            }
            else if (!this.mErrors.Contains(control))
            {
                this.mErrors.Add(control);
            }

            this.mProvider.SetError(control, text);
            control.Focus();
        }
    }
}
