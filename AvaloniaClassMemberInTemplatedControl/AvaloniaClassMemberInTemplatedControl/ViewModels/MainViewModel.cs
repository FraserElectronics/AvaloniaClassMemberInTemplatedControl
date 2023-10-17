using SupportAssy;

namespace AvaloniaClassMemberInTemplatedControl.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    private DataRecord _myDataRecord = new DataRecord() { Value1 = 1 };
    public DataRecord MyDataRecord

    {
        get => _myDataRecord;
        set => _myDataRecord = value;
    }
}

