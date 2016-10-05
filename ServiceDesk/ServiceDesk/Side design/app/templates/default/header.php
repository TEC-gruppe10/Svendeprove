<?php
/**
 * Sample layout
 */

use Helpers\Assets;
use Helpers\Url;
use Helpers\Hooks;

function setActive(){
    return 'class="active"';
};

//initialise hooks
$hooks = Hooks::get();
?>
<!DOCTYPE html>
<html lang="<?php echo LANGUAGE_CODE; ?>">
<head>

	<!-- Site meta -->
	<meta charset="utf-8">
	<?php
	//hook for plugging in meta tags
	$hooks->run('meta');
	?>
	<title><?php echo $data['title'].' - '.SITETITLE; //SITETITLE defined in app/Core/Config.php ?></title>

	<!-- CSS -->
	<?php
	Assets::css(array(
        'https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css',
		'http://fonts.googleapis.com/css?family=Open+Sans:300italic,300,400,400italic,600,600italic,700,700italic,800,800italic|Source+Sans+Pro:400,900,700',
		'http://nepharia.net/static/css/main.css',
	));

	//hook for plugging in css
	$hooks->run('css');
	?>

</head>
<body class="light">
<?php
//hook for running code after body tag
$hooks->run('afterBody');
?>
    <nav id="TopMenu" class="light">
        <ul>
            <li class="logo"><a href="/">Nepharia</a></li>
            <li <?php if($data['active'] === 1) echo setActive(); ?>><a href="/movies/">Movies</a></li>
            <li <?php if($data['active'] === 2) echo setActive(); ?>><a href="/typography/">Typography</a></li>
            <li><a href="/gallery/">Gallery</a></li>
            <li><a href="/About/">About</a></li>
            <li class="search icon right"><span><input placeholder="Search..." type="search"><i class="fa fa-search"></i></span></li>
            <li class="icon"><a href="/contact/"><i class="fa fa-envelope"></i></a></li>
            <li class="icon"><a href="/settings/"><i class="fa fa-cog"></i></a></li>
            <li class="icon"><a href="/login/"><i class="fa fa-user"></i></a></li>
        </ul>
    </nav>
    <main class="light">
