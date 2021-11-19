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
	 		<ul>
	 		<nav><li><a href="" class="button15">Создать БД</a></li>
	 		<?php
	 			$a = array();
   				$file = $_SERVER['DOCUMENT_ROOT'] . '/data.txt';
   				$a = file($file, FILE_IGNORE_NEW_LINES | FILE_SKIP_EMPTY_LINES);
	 			foreach($a as $line_num => $line)
	 			{
	 				echo "<li><a href=''>$line</a></li>";
	 			}
	 		?>
	 		</nav>
	 		</ul>
	 		</div>
  		</div>
  		<div class="column col-2">
    		<form method="POST">
			<p>
				<input type="submit" name="bases"   value="Базы данных">
				<input type="submit" name="console" value="SQL консоль">
			</p>
				<?php
				mysqli_report(MYSQLI_REPORT_ERROR | MYSQLI_REPORT_STRICT);
				if(isset($_POST['bases']))
				{
					include '2.php';
				}
				else if(isset($_POST['console']))
				{
					include '1.php';
				}
				?>

			</form>
  		</div>
	</div>


</body>
</html>