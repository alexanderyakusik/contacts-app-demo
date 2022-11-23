namespace ContactsApp.DAL.JSONFile.IIdentityValueProvider.Interfaces
{
    internal interface IIdentityValueProvider<T>
    {
        T Next();
    }
}
