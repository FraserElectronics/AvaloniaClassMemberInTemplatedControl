using Avalonia;
using Avalonia.Controls.Primitives;

using SupportAssy;

namespace AvaloniaClassMemberInTemplatedControl.Controls;

public class TestTemplatedControl : TemplatedControl
{
    public static readonly DirectProperty<TestTemplatedControl,DataRecord?> RecordProperty =
    AvaloniaProperty.RegisterDirect<TestTemplatedControl, DataRecord?>(nameof(Record), o => o.Record, ( o, v ) => o.Record = v );
    private DataRecord? _record;
    public DataRecord? Record
    {
        get => _record;
        set => SetAndRaise( RecordProperty, ref _record, value );
    }
}