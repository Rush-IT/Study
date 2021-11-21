<?php
$mysqli = false;
//Подключение к БД
function connectDB($name)
{
	global $mysqli;
	$mysqli = new mysqli("localhost", "root", "123", $name);
	$mysqli->query('SELECT * FROM `'.$name.'`');
}
//Отключение от БД
function closeDB($name)
{
	global $mysqli;
	$mysqli->close();
}
//Создание БД
function createDB($name)
{
	global $mysqli;
	$mysqli = new mysqli("localhost", "root", "123");
	$mysqli->query('CREATE DATABASE `'.$name.'`');
}
//Создание таблицы
function createTable($name)
{
	global $mysqli;
	$mysqli = new mysqli("localhost", "root", "123");
	$mysqli->query('CREATE DATABASE `'.$name.'`');
}
?>