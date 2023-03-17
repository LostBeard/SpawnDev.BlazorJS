using Microsoft.AspNetCore.Components;
using SpawnDev.BlazorJS.JSObjects;
using System.Xml.Linq;

namespace SpawnDev.BlazorJS.Test.Pages
{
    class SomeItemType
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool GroupA { get; set; } = true;
        public SomeItemType(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }

    public partial class DragDrop : IDisposable
    {
        ElementReference _dragDropContainer { get; set; }
        CallbackGroup _callbacks = new CallbackGroup();
        List<SomeItemType> _someItems = new List<SomeItemType>();
        HTMLElement? _dragging = null;
        SomeItemType? _draggingItem = null;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                // create some fake data
                Enumerable.Range(0, 5).ToList().ForEach(i => _someItems.Add(new SomeItemType(i, $"Draggable Item {i}")));
                // create and set callbacks
                using var source = new HTMLElement(_dragDropContainer);
                source.AddEventListener("dragend", Callback.Create<DragEvent>(OnDragEnd, _callbacks));
                source.AddEventListener("dragover", Callback.Create<DragEvent>(OnDragOver, _callbacks));
                source.AddEventListener("dragstart", Callback.Create<DragEvent>(OnDragStart, _callbacks));
                source.AddEventListener("drop", Callback.Create<DragEvent>(OnDrop, _callbacks));
            }
        }

        void OnDragStart(DragEvent e)
        {
            JS.Log("OnDragStart", e);
            _dragging = e.Target.JSRefMove<HTMLElement>();
            var itemKey = int.Parse(_dragging.GetAttribute("item-id"));
            _draggingItem = _someItems.Where(o => o.Id == itemKey).FirstOrDefault();
            using var classList = _dragging.ClassList;
            classList.Add("dragging");
            e.Dispose();
        }
        void OnDragOver(DragEvent e)
        {
            JS.Log("OnDragOver", e);
            using var el = e.Target.JSRefMove<HTMLElement>();
            if (el.ClassList.Contains("dropzone"))
            {
                // call preventDefault to allow the UI to show that dropping here is allowed
                e.PreventDefault();
                JS.Log("OnDragOver in dropzone");
            }
            else
            {
                // the UI will show that dropping here is blocked
                JS.Log("OnDragOver outside of dropzone");
            }
            e.Dispose();
        }
        void OnDrop(DragEvent e)
        {
            JS.Log("OnDrop", e);
            e.PreventDefault();
            using var dropTarget = e.Target.JSRefMove<HTMLElement>();
            if (dropTarget.ClassList.Contains("dropzone"))
            {
                _draggingItem.GroupA = dropTarget.ClassList.Contains("dropzone-a");
                JS.Log("Dropped in dropzone");
                StateHasChanged();
            }
            else
            {
                JS.Log("Dropped outside of dropzone");
            }
            e.Dispose();
        }
        void OnDragEnd(DragEvent e)
        {
            JS.Log("OnDragEnd", e);
            using var el = e.Target.JSRefMove<HTMLElement>();
            using var classList = el.ClassList;
            classList.Remove("dragging");
            _dragging?.Dispose();
            _dragging = null;
            _draggingItem = null;
            e.Dispose();
        }

        public void Dispose()
        {
            _callbacks.Dispose();
        }
    }
}
