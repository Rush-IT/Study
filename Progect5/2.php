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
    		<form action="create.php" method="POST">
				<p>
					<input type="text" name="name" placeholder="Название БД" />
					<input type="submit" value="Создать" />
				</p>
			</form>
  		</div>
	</div>
	</body>
</html>