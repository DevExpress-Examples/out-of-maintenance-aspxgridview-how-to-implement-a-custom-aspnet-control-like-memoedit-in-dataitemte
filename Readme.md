<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128534518/15.2.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T367479)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [Default2.aspx](./CS/Default2.aspx) (VB: [Default2.aspx](./VB/Default2.aspx))
* [Default2.aspx.cs](./CS/Default2.aspx.cs) (VB: [Default2.aspx.vb](./VB/Default2.aspx.vb))
* [Default3.aspx](./CS/Default3.aspx) (VB: [Default3.aspx](./VB/Default3.aspx))
* [Default3.aspx.cs](./CS/Default3.aspx.cs) (VB: [Default3.aspx.vb](./VB/Default3.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to implement a custom ASP.NET control like MemoEdit in DataItemTemplate
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t367479/)**
<!-- run online end -->


<p>This example demonstrates how to implement a custom ASP.NET control like <strong>MemoEdit </strong>in the <strong>DataItemTemplate in</strong> two different ways - in markup and code behind.</p>
<p><strong>A markup way</strong></p>
<p>Use these steps:<br>1) Add the <strong>ASPxDropDownEdit</strong> control to the <strong>DataItemTemplate</strong> of a column and configure it.<br>2) Add two custom buttons (<em>Save</em> and <em>Cancel)</em> and the <strong>ASPxMemo</strong> control to the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxDropDownEdit_DropDownWindowTemplatetopic">ASPxDropDownEdit.DropDownWindowTemplate</a>.<br>3) Handle the <strong>Load </strong>event of the <strong>ASPxDropDownEdit</strong> and <strong>ASPxMemo</strong> controls. In this event handler, get a visible index of the current row (use the approach from <a href="https://www.devexpress.com/Support/Center/p/K18282">The general technique of using the Init/Load event handler</a>). Set a unique <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditBase_ClientInstanceNametopic">ClientInstanceName</a> property based on that visible index. <br>4) In the <strong>Load</strong> event handler of the dropdown, add the column's value to the dropdown. Add the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditBase_JSPropertiestopic">JSProperties</a> property to get an index of the dropdown on the client side.<br>5) Add two global variables. Use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientControl_Inittopic">Init</a> event handler to change the visibility of the background image. In the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientDropDownEditBase_DropDowntopic">DropDown</a> event, set the current value to the memo. Use the <strong>OnSaveClick</strong> and <strong>OnCancelClick </strong>handlers of the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientButton_Clicktopic">ASPxClientButton.Click</a> event to save and hide the dropdown:</p>


```js
var dropDownEdit;
var memo;

function OnDropDown(s, e) {
	SetGlobalVariables(s);

	memo.SetText(dropDownEdit.GetValue());
}
function OnCancelClick(s, e) {
	dropDownEdit.HideDropDown();
}
function OnSaveClick(s, e) {
	dropDownEdit.SetValue(memo.GetValue());

	SetInputDisplayFormat(dropDownEdit);

	dropDownEdit.HideDropDown();
}		
function SetInputDisplayFormat(dde) {
	var input = dde.GetInputElement();
	input.style.display = (input.value != "") ? "none" : "block";
}
function SetGlobalVariables(dde) {
	dropDownEdit = dde;
	memo = ASPxClientControl.GetControlCollection().GetByName("memo_" + dde.cpIndex);
}
```


<p>6) Add the following <strong>CSS</strong> rules on the page and assign the <strong>CSS</strong> class to the <strong>ASPxMemo</strong> control: </p>


```css
.memo textarea {
	padding: 0px !important;
	resize: both;
	margin: 0px !important;
}

.memo td {
	padding: 0px !important;
}
```


<p>This workaround adds the resize <em>"grip"</em>  at the bottom right of this control.</p>
<p><strong><br>A code-behind way </strong></p>
<p>Use the following steps:<br>1) In code behind, add two <strong>ITemplate</strong> classes. The first class will implement a template for the grid, the second - for the dropdown.<br>2) Handle the <strong>DataBinding</strong> event of the grid. In the event handler, add the first class instance to the target column.<br>3) In the first class, define <strong>ASPxDropDownEdit </strong>(based on <a href="https://www.devexpress.com/Support/Center/p/K18282">The general technique of using the Init/Load event handler</a>) and find a visible index (use the approach from the <a href="https://www.devexpress.com/Support/Center/p/KA18606">How to create controls dynamically</a> KB article). Define all the necessary properties. Create a unique ID and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditBase_ClientInstanceNametopic">ClientInstanceName</a> based on the visible index and handle client-side events. Add the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditBase_JSPropertiestopic">JSProperties</a> property to get an index of the dropdown on the client side. Add the second class instance to the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxDropDownEdit_DropDownWindowTemplatetopic">ASPxDropDownEdit.DropDownWindowTemplate</a>.<br>4) Add the constructor and a private variable to the second class to take the container of the dropdown to define a visible index.<br>5) In the second class, define <strong>ASPxMemo</strong> and two buttons. Find a visible index of the grid. Define all the necessary properties. Create a unique <strong>ID</strong> and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditBase_ClientInstanceNametopic">ClientInstanceName</a> based on the visible index and handle client-side events.<br>6) Repeat steps 5 and 6 from the approach with markup.</p>

<br/>


