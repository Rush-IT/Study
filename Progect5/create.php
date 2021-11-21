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
		//Создание БД
		createDB($name);
		//Проверка на наличие
		$file = $_SERVER['DOCUMENT_ROOT'] . '/data.txt';
		$flag = false;
   		$a = file($file, FILE_IGNORE_NEW_LINES | FILE_SKIP_EMPTY_LINES);
		foreach($a as $line_num => $line)
		{
			if($line == $name) $flag = true;
		}
		//Добавление названия в файл
		if (!$flag) file_put_contents($file, "\r\n" . $name);

	 ?>
	 //Контейнер для разделения страницы
	 <div class="container">
	 	//Список БД в левой части страницы
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
  			<h3>Создать таблицу</h3>
    		<form action="databasesWork.php" method="POST">
			<p>
				<input type="text" name="name" placeholder="Название таблицы" />
				<input type="text" name="number" placeholder="Количество столбцов" />
			</p>
			<input type="submit" value="Вперед" />
		</form>
  		</div>
	</div>

</body>
</html>