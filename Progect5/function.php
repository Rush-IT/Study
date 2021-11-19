<?php
$mysqli = false;
function connectDB($name)
{
	global $mysqli;
	$mysqli = new mysqli("localhost", "root", "123", $name);
	$mysqli->query('SELECT * FROM `'.$name.'`');
}
function closeDB($name)
{
	global $mysqli;
	$mysqli->close();
}
function createDB($name)
{
	global $mysqli;
	$mysqli = new mysqli("localhost", "root", "123");
	$mysqli->query('CREATE DATABASE `'.$name.'`');
}
?>