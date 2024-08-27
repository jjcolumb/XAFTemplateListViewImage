using DevExpress.Blazor;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors.ActionControls;
using DevExpress.ExpressApp.Blazor.Templates;
using DevExpress.ExpressApp.Blazor.Templates.ContextMenu.ActionControls;
using DevExpress.ExpressApp.Blazor.Templates.Toolbar.ActionControls;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.Persistent.Base;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace XAFTemplateListViewImage.Blazor.Server.Templates
{
    public class PopupWindowTemplate2 : PopupWindowTemplateBase, ISupportActionsToolbarVisibility, ISupportListEditorInlineActions, ISupportListEditorContextMenuActions, ITemplateToolbarProvider
    {
        public PopupWindowTemplate2() : base()
        {
            Popup.MinHeight = "200px";
            Popup.MinWidth = "300px";
            Popup.Width = "min(800px, 100%)";
            Popup.MaxHeight = "calc(100vh - var(--is-widescreen) * 3.5rem)";

            IsActionsToolbarVisible = true;
            Toolbar = new DxToolbarAdapter(new DxToolbarModel());
            Toolbar.AddActionContainer(nameof(PredefinedCategory.ObjectsCreation));
            Toolbar.AddActionContainer(nameof(PredefinedCategory.Search), ToolbarItemAlignment.Right);
            Toolbar.AddActionContainer(nameof(PredefinedCategory.Filters), ToolbarItemAlignment.Right);
            Toolbar.AddActionContainer(nameof(PredefinedCategory.FullTextSearch), ToolbarItemAlignment.Right);

            BottomToolbar = new DxToolbarAdapter(new DxToolbarModel());
            BottomToolbar.AddActionContainer(nameof(PredefinedCategory.Diagnostic), ToolbarItemAlignment.Right);
            BottomToolbar.AddActionContainer(DialogController.DialogActionContainerName, ToolbarItemAlignment.Right);
            BottomToolbar.ToolbarModel.SizeMode = SizeMode.Large;

            ListEditorActionColumnAdapter = new ListEditorActionColumnAdapter();
            ListEditorActionColumnAdapter.AddActionContainer(nameof(PredefinedCategory.ListView));
            ListEditorActionColumnAdapter.AddActionContainer(nameof(PredefinedCategory.Edit));
            ListEditorActionColumnAdapter.AddActionContainer(nameof(PredefinedCategory.RecordEdit));

            DxContextMenuAdapter = new DxContextMenuAdapter(new DxContextMenuModel());
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.ObjectsCreation));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.Save));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.SaveOptions), isDropDown: true, defaultActionId: "SaveAndNew", autoChangeDefaultAction: true);
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.Edit));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.RecordEdit));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.UndoRedo));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.Print));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.View));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.Export));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.Reports));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.OpenObject));
            DxContextMenuAdapter.AddActionContainer(nameof(PredefinedCategory.Menu));
        }
        protected override IEnumerable<IActionControlContainer> GetActionControlContainers() =>
            Toolbar.ActionContainers.Concat(BottomToolbar.ActionContainers.Concat(ListEditorActionColumnAdapter.ActionContainers.Union(DxContextMenuAdapter.ActionContainers)));
        protected override RenderFragment CreateComponent() => PopupWindowTemplate2Component.Create(this);

        public bool IsActionsToolbarVisible { get; private set; }
        public DxToolbarAdapter Toolbar { get; }
        public DxToolbarAdapter BottomToolbar { get; }
        public ListEditorActionColumnAdapter ListEditorActionColumnAdapter { get; }
        public DxContextMenuAdapter DxContextMenuAdapter { get; }

        #region ISupportActionsToolbarVisibility
        void ISupportActionsToolbarVisibility.SetVisible(bool isVisible) => IsActionsToolbarVisible = isVisible;
        #endregion
    }
}
