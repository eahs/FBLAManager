using FBLAManager.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class MemberInfo
{
    public string Name { get; set; }
    public long Number { get; set; }
}


public class MembersPageViewModel : BaseViewModel
{
    private ObservableCollection<MemberInfo> contactList;
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<MemberInfo> ContactList
    {
        get { return contactList; }
        set { contactList = value; }
    }
    public MembersPageViewModel()
    {
        ContactList = new ObservableCollection<MemberInfo>();
        ContactList.Add(new MemberInfo { Name = "Aaron", Number = 7363750 });
        ContactList.Add(new MemberInfo { Name = "Adam", Number = 7323250 });
        ContactList.Add(new MemberInfo { Name = "Adrian", Number = 7239121 });
        ContactList.Add(new MemberInfo { Name = "Alwin", Number = 2329823 });
        ContactList.Add(new MemberInfo { Name = "Alex", Number = 8013481 });
        ContactList.Add(new MemberInfo { Name = "Alexander", Number = 7872329 });
        ContactList.Add(new MemberInfo { Name = "Barry", Number = 7317750 });
    }
}