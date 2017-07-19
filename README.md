# JQuery DataTable from JSON

Populando um controle JQuery DataTable a partir de um JSON | Populating a JQuery DataTable from a JSON

### Crie o controller chamado HomeController.cs | Create the controller called HomeController.cs

```csharp
using System.Web.Mvc;

namespace JQueryDataTableFromJson.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
```

### Crie a view chamada Index.cshtml | Create the view called Index.cshtml

```csharp
@{
    ViewBag.Title = "JQuery DataTable From JSON";
}
```
```html
<h2>JQuery DataTable From JSON</h2>
```

### Crie uma action que retorne o JSON com os dados | Create an action that returns the JSON with the data

```csharp
using System.Collections.Generic;
```
```
using System.Web.Mvc;

namespace JQueryDataTableFromJson.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
```
```csharp
	public ActionResult Data()
	{
		var data = new
		{
			data = new List<object>
			{
				new { id = 1, name = "John"},
				new {id = 2, name = "Peter"},
				new {id = 3, name = "Ben"},
				new {id = 4, name = "Clark"},
				new {id = 5, name = "Lois"},
				new {id = 6, name = "Kara"}
			}
		};

		return Json(data, JsonRequestBehavior.AllowGet);
	}
```
```
}
```

### Instale o pacote Nuget | Install the Nuget package

```powershell
Install-Package jquery.datatables
```

### Inclua uma chamada de script em _Layout.cshtml | Include a script call in _Layout.cshtml

```
<script src="~/Scripts/jquery-1.10.2.min.js"></script>
<script src="~/Scripts/bootstrap.min.js"></script>
```
```html
<script src="~/Scripts/DataTables/jquery.dataTables.js"></script>
```

### Inclua uma seção de script em _Layout.cshtml após as chamadas dos scripts | Include a script section in _Layout.cshtml after the script call

```
<script src="~/Scripts/jquery-1.10.2.min.js"></script>
<script src="~/Scripts/bootstrap.min.js"></script>
<script src="~/Scripts/DataTables/jquery.dataTables.js"></script>
```
```csharp
@RenderSection("script", required: false)
```

### Inclua uma tabela HTML em Index.cshtml | Include a HTML table in Index.cshtml

```csharp
@{
    ViewBag.Title = "JQuery DataTable From JSON";
}
```
```html
<h2>JQuery DataTable From JSON</h2>

<table id="names" class="display" width="100%" cellspacing="0">
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
        </tr>
    </thead>
    <tfoot>
        <tr>
            <th>Id</th>
            <th>Name</th>
        </tr>
    </tfoot>
</table>
```

### Inicialize o DataTable dentro da seção de script | Initialize the DataTable inside the script section


```
@{
    ViewBag.Title = "JQuery DataTable From JSON";
}
<h2>JQuery DataTable From JSON</h2>

<table id="names" class="display" width="100%" cellspacing="0">
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
        </tr>
    </thead>
    <tfoot>
        <tr>
            <th>Id</th>
            <th>Name</th>
        </tr>
    </tfoot>
</table>
```
```csharp
@section script
{
```
```javascript
    <script>
        $(document).ready(function () {
            $('#names').DataTable({
                "ajax": "Data",
                "columns": [
                    { "data": "id" },
                    { "data": "name" }
                ]
            });
        });
    </script>
```
```csharp
}
```