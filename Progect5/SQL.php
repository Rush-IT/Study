<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>LB_5</title>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>

	<div class="container">
  		<div class="column col-1">
    		<h2>Список БД</h2>
    		<div class="vl">
	 		<?php include'left.php';?>
	 		</div>
  		</div>
  		<div class="column col-2">
	    	<form method="POST">
			<p>
				<input class="butt2" type="submit" name="databases"   value="Базы данных"/>
				<input class="butt2" type="submit" name="console" value="SQL консоль"/>
			</p>
				<?php
				mysqli_report(MYSQLI_REPORT_ERROR | MYSQLI_REPORT_STRICT);
				if(isset($_POST['createBD']))
				{
					echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /2.php">';
				}
				else if (isset($_POST['bases']))
				{
					include '1.php';
				}
				else if(isset($_POST['databases']))
				{
					echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /index.php">';
				}
				?>
				<p><input type="text" name="sql"/>
					<input class="butt2" type="submit" value="Вперед"/></p>
				<?php
					if(isset($_POST['sql']))
					{
						$mysql = $_POST['sql'];
						$mysql
						$mysqli = new mysqli("localhost", "root", "123");
						$mysqli->query("$mysql");
					}
				?>
			</form>
  		</div>
	</div>


</body>
</html>