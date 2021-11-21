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
    			<?php include'left.php'; ?>
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
					$name = $_POST['bases'];
					echo $name;
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