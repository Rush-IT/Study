<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Document</title>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
	<body>
	<div class="container">
  		<div class="column col-1">
    		<h2>Список БД</h2>
    			<div class="vl">
	 			<?php include 'left.php'; ?>
	 		</div>
  		</div>
  		<div class="column col-2">
  			<h3>Создать базу данных<h3>
    		<form method="POST">
				<p>
					<input class='butt2' type="text" name="name" placeholder="Название БД" />
					<input class='butt2' type="submit" value="Создать" />
				</p>
			</form>
			<?php
				if(isset($_POST['console']))
				{

				}
				else if(isset($_POST['createT']))
				{

				}
				else if (isset($_POST['name']))
				{
					include 'function.php';
					createDB($_POST['name']);
					echo '<meta http-equiv = "Refresh" CONTENT="0; URL = /index.php">';
				}
			?>
  		</div>
	</div>
	</body>
</html>