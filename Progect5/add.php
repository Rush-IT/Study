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
				<?php

				?>
			</p>
			</form>
			<form action="add.php">
				<p>
    				<button class='butt2' type="submit">Добавить строку</button>
    			</p>
    		</form>
  		</div>
	</div>

</body>
</html>