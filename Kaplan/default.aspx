<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Kaplan._default" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Fundación Kaplan</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Google Web Fonts -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,regular,600&subset=latin%2Clatin-ext" rel="stylesheet" type="text/css">

    <!-- Font Awesome -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">

    <!-- Date Picker -->
    <link href="css/angular-moment-picker.min.css" rel="stylesheet" />

    <!-- Animate CSS -->
    <link rel="stylesheet" href="css/animate.css">

    <!-- Template CSS Files  -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/media.css" rel="stylesheet">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- Fav and touch icons -->

    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/fav-144.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/fav-114.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/fav-72.png">
    <link rel="apple-touch-icon-precomposed" href="images/fav-57.png">
    <link rel="shortcut icon" href="images/fav.png">

    <script src="js/script/jquery-1.9.1.min.js"></script>
</head>
<body ng-app="app" ng-cloak ng-controller="defaultController">
    <!-- Nav -->
    <nav class="navbar navbar-default" role="navigation">
        <div class="container">
            <!-- LOGO -->
            <a class="navbar-brand page-scroll" href="index.html"><i class="fa fa-heartbeat" aria-hidden="true"></i>Fundación<span class="text-blue text-light">Kaplan</span></a>
            <!-- END / LOGO -->

            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <!-- Hidden li included to remove active class from about link when scrolled up past about section -->
                    <li class="hidden">
                        <a class="page-scroll" href="#page-top"></a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Inicio</a>
                        <ul class="dropdown-menu dropdown-menu-left">
                            <li><a href="index.html">Home Default</a></li>
                            <li><a href="home-form.html">Home With Form</a></li>
                            <li><a href="index-v2.html">Home Colorful Navigation</a></li>
                            <li><a href="index-v3.html">Home Without Slider</a></li>
                            <li><a href="../boxed/index.html">Home Boxed</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Nosotros</a>
                        <ul class="dropdown-menu dropdown-menu-left">
                            <li><a href="about.html">About us</a></li>
                            <li><a href="faq.html">FAQ</a></li>
                            <li><a href="testimonials.html">Testimonials</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Especialistas</a>
                        <ul class="dropdown-menu dropdown-menu-left">
                            <li class="dropdown dropdown-submenu">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Doctors <i class="fa fa-angle-down" aria-hidden="true"></i></a>
                                <ul class="dropdown-menu">
                                    <li><a href="doctors.html">Doctors</a></li>
                                    <li><a href="doctor-profile.html">Doctor Profile</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Departments</a>
                        <ul class="dropdown-menu dropdown-menu-left">
                            <li><a href="departments.html">Departments</a></li>
                            <li><a href="department-single.html">Department Single</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="timetable.html">Timetable</a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Feautures</a>
                        <ul class="dropdown-menu dropdown-menu-left">
                            <li><a href="buttons.html">Buttons</a></li>
                            <li><a href="tabs.html">Tabs</a></li>
                            <li><a href="typography.html">Typography</a></li>
                            <li><a href="icons.html">Icons</a></li>
                            <li><a href="grid.html">Grids</a></li>
                            <li><a href="alerts.html">Notifications</a></li>
                            <li><a href="404.html">404</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Blog</a>
                        <ul class="dropdown-menu dropdown-menu-left">
                            <li><a href="blog.html">Blog</a></li>
                            <li><a href="blog-single.html">Blog Single</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="contact.html">Contact</a>
                    </li>
                </ul>
                <!-- END / NAVBAR RIGHT -->
            </div>
        </div>
        <!-- END CONTAINER -->
    </nav>
    <!-- ./end Nav -->

    <div id="main">
        <div ng-view></div>
    </div>

    <!-- Scroll to top -->
    <div class="scroll-top">
        <a href="#totop"><i class="fa fa-angle-double-up"></i></a>
    </div>
    <!-- ./end Scroll to top -->
    
    <!-- Script Files -->
      <script src="js/script/jquery.min.js"></script>
    <script src="js/script/bootstrap.js"></script>
    <script src="js/script/main.js"></script>
    <script src="js/script/jquery.easing.min.js"></script>
    <%--<script src="js/script/bootstrap-datepicker.js"></script>--%>
    <script src="js/script/jquery.appear.js"></script>
    <script src="js/script/jquery.countTo.js"></script>
        
    <script src="js/script/angular.min.js"></script>
    <script src="js/script/angular-route.min.js"></script>
    <script src="js/script/angular-locale_es-cl.js"></script>
    <script src="js/script/angular-modal-service.js"></script>
    <script src="js/script/moment-with-locales.js"></script>
    <script src="js/script/angular-ui-notification.min.js"></script>
    <script src="js/script/angular-moment-picker.min.js"></script>
    <script src="js/script/dirPagination.js"></script>

    <script src="js/app.js"></script>   
    <script src="js/controllers/defaultController.js"></script>    
    <script src="js/controllers/fichaController.js"></script>
    <script src="js/services/tipoService.js"></script>
    <script src="js/services/fichaService.js"></script>
</body>
</html>