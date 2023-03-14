using Microsoft.AspNetCore.Components;
using SpawnDev.BlazorJS.Test.Services;
using SpawnDev.BlazorJS.Test.UnitTests;
using System.Reflection;

namespace SpawnDev.BlazorJS.Test.Pages {
    public partial class UnitTests : IDisposable {
        [Inject]
        UnitTestService unitTestService { get; set; }

        bool _beenInit = false;

        protected override void OnAfterRender(bool firstRender) {
            base.OnAfterRender(firstRender);
            if (!_beenInit) {
                _beenInit = true;
                unitTestService.TestStatusChanged += UnitTestSet_TestStatusChanged;
                unitTestService.SetTestTypes(new[] {
                    typeof(BlazorJSUnitTest),
                });
            }
        }

        private void UnitTestSet_TestStatusChanged() {
            StateHasChanged();
        }

        public void Dispose() {
            if (_beenInit ) {
                _beenInit = false;
                unitTestService.CancelTests();
                unitTestService.TestStatusChanged -= UnitTestSet_TestStatusChanged;
            }
        }
    }
}
