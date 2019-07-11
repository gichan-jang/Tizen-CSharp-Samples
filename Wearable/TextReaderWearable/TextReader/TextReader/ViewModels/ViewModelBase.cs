using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextReader.ViewModels
{
    /// <summary>
    /// Class that provides basic functionality for view models.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region properties

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region methods

        /// <summary>
        /// Calls OnPropertyChanged() after value modification.
        /// </summary>
        /// <param name="storage">Value storage object.</param>
        /// <param name="value">Value to set.</param>
        /// <param name="propertyName">Automatically obtained property name.</param>
        /// <typeparam name="T">Property value type.</typeparam>
        /// <returns>True if value was changed, false if value isn't different from current.</returns>
        protected bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        /// <summary>
        /// Invokes PropertyChanged with automatically obtained property name.
        /// </summary>
        /// <param name="propertyName">Name of the changed property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}