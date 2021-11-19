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
		$name = $_POST['name'];
		include 'function.php';
		createDB($name);
	 ?>
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
    		<form action="index.php" method="POST">
			<p></p>
			<p> <input type="submit" value="Назад" /> </p>
		</form>
  		</div>
	</div>
	 <div class="vl">

	 </div>
	 <ul>



	</ul>
</body>
</html>