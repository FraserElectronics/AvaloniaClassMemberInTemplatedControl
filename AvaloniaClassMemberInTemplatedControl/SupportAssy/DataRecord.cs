using CommunityToolkit.Mvvm.ComponentModel;

namespace SupportAssy
{
    public partial class DataRecord : ObservableObject
    {
        [ObservableProperty]
        private float value1 = 1.234f;
    }
}