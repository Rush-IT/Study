<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Document</title>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>

	<?php
	include 'function.php';
	createDB($_POST['name']);
	?>
	 <div class="container">
  		<div class="column col-1">
    		<h2>Список БД</h2>
    		<div class="vl">
	 		<?php include'left.php'; ?>
	 		</div>
  		</div>
  		<div class="column col-2">
  			<h3>Создать таблицу</h3>
    		<form method="POST">
			<p>
				<input class="butt2" type="text" name="table" placeholder="Название таблицы" />
				<input class="butt2" type="text" name="number" placeholder="Количество столбцов" />
				<input class="butt2" type="submit" value="Вперед" />
			</p>
			<p><input class="butt2" type="submit" name="back" value="Назад"/></p>

		</form>
		<?php
			if($_POST['table'])
			{
				//$table = $_POST['table'];
				file_put_contents('table.txt', $_POST['table']);
				//$number = $_POST['number'];
				file_put_contents('number.txt', $_POST['number']);
				echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /crtT.php">';
			}
			else if($_POST['back'])
			{
				echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /1.php">';
			}
		?>
  		</div>
	</div>

</body>
</html>