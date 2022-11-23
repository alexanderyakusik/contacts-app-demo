using ContactsApp.DAL.JSONFile.IIdentityValueProvider.Interfaces;

namespace ContactsApp.DAL.JSONFile.IIdentityValueProvider
{
    internal class BaseIdentityValueProvider : IIdentityValueProvider<int>
    {
        private readonly int _startingValue;
        private readonly int _increment;

        private int _value;

        protected BaseIdentityValueProvider(int startingValue, int increment)
        {
            _startingValue = startingValue;
            _increment = increment;

            _value = _startingValue - _increment;
        }

        public int Next()
        {
            return _value += _increment;
        }

        protected void SetValue(int value)
        {
            _value = value;
        }
    }
}
