<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Agenda._default" %>

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
    <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet">

    <!-- Notification CSS -->
    <link rel="stylesheet" href="css/angular-ui-notification.min.css" />

    <!-- Google Web Fonts -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,regular,600&subset=latin%2Clatin-ext" rel="stylesheet" type="text/css">

    <!-- Font Awesome -->
    <link rel="stylesheet" href="css/font-awesome-4.7.0/css/font-awesome.min.css">

    <!-- Date Picker -->
    <link href="css/angular-moment-picker.min.css" rel="stylesheet" />

    <!-- Animate CSS -->
    <link rel="stylesheet" href="css/animate.css">

    <!-- Template CSS Files  -->
    <link href="css/style.css" rel="stylesheet">
    <link href="css/media.css" rel="stylesheet">

    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/fav-144.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/fav-114.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/fav-72.png">
    <link rel="apple-touch-icon-precomposed" href="images/fav-57.png">
    <link rel="shortcut icon" href="images/fav.png">

    <script src="js/script/jquery-3.1.1.min.js"></script>
</head>
<body ng-app="app" ng-cloak ng-controller="defaultController" onundo="javascript:window.localStorage.clear()">


    <div id="main">
        <div ng-view></div>
    </div>
    <!-- Footer -->
    <footer>
        <!-- Container -->
        <div class="container">
            <!-- Row Begin -->
            <div class="row">

                <div class="col-md-3">
                    <%--<div class="widget">
                        <h2 class="logo-font"><i class="fa fa-heartbeat" aria-hidden="true"></i>Kosi<span class="text-blue text-light">Medic</span></h2>
                        <br>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
                    </div>--%>
                </div>

                <div class="col-md-3">
                   <%-- <div class="widget">
                        <h3>Socials <span class="bottom-lin"></span></h3>
                        <ul>
                            <li>Facebook</li>
                            <li>Twitter</li>
                            <li>Youtube</li>
                            <li>Linkedin</li>
                        </ul>
                    </div>--%>
                </div>

                <div class="col-md-3">
                 <%--   <div class="widget">
                        <h3>About Us</h3>
                        <ul>
                            <li><a href="doctors.html">Doctors</a></li>
                            <li><a href="departments.html">Departments</a></li>
                            <li><a href="timetable.html">Timetable</a></li>
                            <li><a href="contact.html">Contact</a></li>
                        </ul>
                    </div>--%>
                </div>

                <div class="col-md-3">
                   <%-- <div class="widget">
                        <h3>Contact</h3>
                        <ul>
                            <li>My Street, NY 10036, United States</li>
                            <li>Phone: 1-800-555-5555</li>
                            <li>Email: example@kosimedic.com</li>
                            <li>Office Offers: 09:00am - 17:00pm</li>
                        </ul>
                    </div>--%>
                </div>
            </div>
            <!-- ./end Row -->
        </div>
        <!-- ./end Container -->
        <!-- Footer Copyright -->
        <div class="footer-slogan">
            &copy; 2018 Fundación Kaplan
        </div>
        <!-- ./end Footer Copyright -->
    </footer>
    <!-- Scroll to top -->
    <div class="scroll-top">
        <a href="#totop"><i class="fa fa-angle-double-up"></i></a>
    </div>
    <!-- ./end Scroll to top -->



    <!-- Script Files -->
    <script src="js/script/bootstrap/bootstrap.min.js"></script>
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
    <script src="js/controllers/reservaController.js"></script>
    <script src="js/controllers/agendaDiaHoraController.js"></script>
    <script src="js/controllers/calendarioController.js"></script>
    <script src="js/controllers/loginController.js"></script>
    <script src="js/controllers/pacienteController.js"></script>
    <script src="js/controllers/especialistaController.js"></script>
    <script src="js/controllers/headerController.js"></script>
    <script src="js/controllers/especialistaMisHorasController.js"></script>
    <script src="js/controllers/especialistaAusenciasController.js"></script>
    <script src="js/controllers/licenciaController.js"></script>
    <script src="js/controllers/reservaAnularController.js"></script>
    <script src="js/controllers/reservaObservacionController.js"></script>
    <script src="js/controllers/planController.js"></script>
    <script src="js/controllers/finalizarPlanController.js"></script>

    <script src="js/services/tipoService.js"></script>
    <script src="js/services/planService.js"></script>
    <script src="js/services/agendaDiaHoraService.js"></script>
    <script src="js/services/calendarioService.js"></script>
    <script src="js/services/reservaService.js"></script>
    <script src="js/services/pacienteService.js"></script>
    <script src="js/services/especialistaService.js"></script>
    <script src="js/services/licenciaService.js"></script>
    <script src="js/services/loginService.js"></script>
    <script src="js/services/WindowsService.js"></script>
</body>
</html>
