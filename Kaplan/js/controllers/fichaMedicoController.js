app.controller("fichaMedicoController", ['$scope', 'Notification', 'LoginService', '$location', 'tipoService', 'fichaService',
function ($scope, Notification, LoginService, $location, tipoService, fichaService) {
    if (!LoginService.getisAuthenticated() == true) {
        LoginService.getCerrarSesion();
        $location.path('cerrarsesion');
    } else {
        /*Validacion de Carga inicial*/
        waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
        $scope.loading = true;
        $scope.mostrarReporte = true;
        $scope.loadingTipoRegion = true;
        $scope.loadingTipoComuna = true;
        $scope.loadingPlanes = true;
        $scope.loadingTiposValoracion = true;
        $scope.StopLoading = function () {
            $scope.loading = !(!$scope.loadingTipoRegion && !$scope.loadingTipoComuna && !$scope.loadingPlanes && !$scope.loadingTiposValoracion);
            if (!$scope.loading) { waitingDialog.hide(); }
        };
        /*Fin*/

        /*Validacion de perfil para editar la ficha*/
        if (parseInt(LoginService.getTipo()) == 2) {
            $scope.FormEditabe = false;
        } else {
            $scope.FormEditabe = true;
        };
        /*Fin*/

        /*Creacion de input variables*/
        $scope.columnsHistoriaCardiopatia = [{ colId: 'col1', Historia: '', Id: -1 }];

        $scope.addNewColumnHistoriaCardiopatia = function () {
            var newItemNo = $scope.columnsHistoriaCardiopatia.length + 1;
            $scope.columnsHistoriaCardiopatia.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnHistoriaCardiopatia = function (index) {
            $scope.columnsHistoriaCardiopatia.splice(index, 1);
        };
        //-----------------------------------------------------------//
        $scope.columnsHistoriaCronica = [{ colId: 'col1', Historia: '', Id: -1 }];

        $scope.addNewColumnHistoriaCronica = function () {
            var newItemNo = $scope.columnsHistoriaCronica.length + 1;
            $scope.columnsHistoriaCronica.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnHistoriaCronica = function (index) {
            $scope.columnsHistoriaCronica.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsOtraCirugia = [{ colId: 'col1', Cirugia: '', Id: -1, Fecha: '' }];

        $scope.addNewColumnOtraCirugia = function () {
            var newItemNo = $scope.columnsOtraCirugia.length + 1;
            $scope.columnsOtraCirugia.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnOtraCirugia = function (index) {
            $scope.columnsOtraCirugia.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsBetabloqueador = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnBetabloqueador = function () {
            var newItemNo = $scope.columnsBetabloqueador.length + 1;
            $scope.columnsBetabloqueador.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnBetabloqueador = function (index) {
            $scope.columnsBetabloqueador.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsBloqueadorCorrientes = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnBloqueadorCorrientes = function () {
            var newItemNo = $scope.columnsBloqueadorCorrientes.length + 1;
            $scope.columnsBloqueadorCorrientes.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnBloqueadorCorrientes = function (index) {
            $scope.columnsBloqueadorCorrientes.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsIECA = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnIECA = function () {
            var newItemNo = $scope.columnsIECA.length + 1;
            $scope.columnsIECA.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnIECA = function (index) {
            $scope.columnsIECA.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsARA2 = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnARA2 = function () {
            var newItemNo = $scope.columnsARA2.length + 1;
            $scope.columnsARA2.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnARA2 = function (index) {
            $scope.columnsARA2.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsNitratos = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnNitratos = function () {
            var newItemNo = $scope.columnsNitratos.length + 1;
            $scope.columnsNitratos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnNitratos = function (index) {
            $scope.columnsNitratos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAnticoagulanteOral = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAnticoagulanteOral = function () {
            var newItemNo = $scope.columnsAnticoagulanteOral.length + 1;
            $scope.columnsAnticoagulanteOral.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAnticoagulanteOral = function (index) {
            $scope.columnsAnticoagulanteOral.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsEstatina = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnEstatina = function () {
            var newItemNo = $scope.columnsEstatina.length + 1;
            $scope.columnsEstatina.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnEstatina = function (index) {
            $scope.columnsEstatina.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAntiplaquetario = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAntiplaquetario = function () {
            var newItemNo = $scope.columnsAntiplaquetario.length + 1;
            $scope.columnsAntiplaquetario.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAntiplaquetario = function (index) {
            $scope.columnsAntiplaquetario.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsHipoglicemiante = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnHipoglicemiante = function () {
            var newItemNo = $scope.columnsHipoglicemiante.length + 1;
            $scope.columnsHipoglicemiante.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnHipoglicemiante = function (index) {
            $scope.columnsHipoglicemiante.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsEsteroides = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnEsteroides = function () {
            var newItemNo = $scope.columnsEsteroides.length + 1;
            $scope.columnsEsteroides.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnEsteroides = function (index) {
            $scope.columnsEsteroides.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsDiuretico = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnDiuretico = function () {
            var newItemNo = $scope.columnsDiuretico.length + 1;
            $scope.columnsDiuretico.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnDiuretico = function (index) {
            $scope.columnsDiuretico.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAlopurinol = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAlopurinol = function () {
            var newItemNo = $scope.columnsAlopurinol.length + 1;
            $scope.columnsAlopurinol.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAlopurinol = function (index) {
            $scope.columnsAlopurinol.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsDigitalicos = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnDigitalicos = function () {
            var newItemNo = $scope.columnsDigitalicos.length + 1;
            $scope.columnsDigitalicos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnDigitalicos = function (index) {
            $scope.columnsDigitalicos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsAntiarritmicos = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnAntiarritmicos = function () {
            var newItemNo = $scope.columnsAntiarritmicos.length + 1;
            $scope.columnsAntiarritmicos.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnAntiarritmicos = function (index) {
            $scope.columnsAntiarritmicos.splice(index, 1);
        };
        //---------------------------------------------------------//
        $scope.columnsOtros = [{ colId: 'col1', Descripcion: '', Id: -1, Dosis: '' }];

        $scope.addNewColumnOtros = function () {
            var newItemNo = $scope.columnsOtros.length + 1;
            $scope.columnsOtros.push({ 'colId': 'col' + newItemNo });
        };

        $scope.removeColumnOtros = function (index) {
            $scope.columnsOtros.splice(index, 1);
        };
        /*Fin*/

        /*Accion de para avanzar o retroceder en un tabpanel*/
        $scope.next = function () {
            $('.nav-tabs > .active').next('li').find('a').each(function () {
                $(this).attr("data-toggle", "tab");
            });
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        };

        $scope.previous = function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        };
        /*Fin*/

        /*Tipo Services*/
        tipoService.getTipoRegion().then(function (result) {
            $scope.TipoRegiones = result.data;
            $scope.loadingTipoRegion = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Region' };
            Notification.error(msg);
        });

        tipoService.getTipoComuna().then(function (result) {
            $scope.TipoComunas = result.data;
            $scope.loadingTipoComuna = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Comuna' };
            Notification.error(msg);
        });

        tipoService.getTipoValoracion().then(function (result) {
            $scope.TiposRespiracion = result.data;
            $scope.TiposAlimentacion = result.data;
            $scope.TiposEliminacion = result.data;
            $scope.TiposDescanso = result.data;
            $scope.TiposHigienePiel = result.data;
            $scope.TiposActividades = result.data;
            $scope.TiposVestirse = result.data;
            $scope.TiposComunicarse = result.data;
            $scope.TiposAutoRealizacion = result.data;
            $scope.loadingTiposValoracion = false;

            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Tipo Valoraciones' };
            Notification.error(msg);
        });
        /*Fin*/

        /*Carga de Planes*/
        fichaService.getPlanesxRut(parseInt(fichaService.getRutPaciente())).then(function (result) {
            $scope.Planes = result.data;
            $scope.loadingPlanes = false;
            $scope.StopLoading();
        }, function (reason) {
            msg = { title: 'Error Listar Planes' };
            Notification.error(msg);
        });
        /*Fin*/

        /*Funciones*/
        $scope.CambioPlan = function (plan) {
            if (typeof plan !== 'undefined') {
                fichaService.getSesionesxPlan(plan, 2).then(function (result) {
                    $scope.Sesiones = result.data;
                }, function (reason) {
                    msg = { title: 'Error Listar Planes' };
                    Notification.error(msg);
                });
            };
        };

        $scope.CambiarSesion = function (sesion) {
            if (typeof sesion !== 'undefined') {
                waitingDialog.show('Cargando Ficha...', { dialogSize: 'sm' });
                fichaService.getFichaEnfermeriaxReserva(sesion).then(function (result) {
                    if (result.data.length !== 0) {
                        $scope.mostrarReporte = false;
                        $scope.Ficha = result.data;
                        $scope.columnsMedicamentos = $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria;
                        $scope.columnsEvolucion = $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria;
                        for (i = 0; i < $scope.columnsEvolucion.length; i++) {
                            $scope.columnsEvolucion[i].Fecha = moment($scope.columnsEvolucion[i].Fecha);
                        }
                        $scope.columnsDiagnostico = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico;
                        $scope.columnsIntervenciones = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion;
                        $scope.columnsIndicadores = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores;
                        $scope.Ficha.FichaEnfermeria.FechaDiagnostico = moment($scope.Ficha.FichaEnfermeria.FechaDiagnostico);
                        $scope.Ficha.FichaEnfermeria.FechaCxProced = moment($scope.Ficha.FichaEnfermeria.FechaCxProced);
                        $scope.Ficha.FichaEnfermeria.FechaAlta = moment($scope.Ficha.FichaEnfermeria.FechaAlta);
                        fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                            $scope.Paciente = result.data;
                            $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                            $('#collapseDataPaciente').collapse('show');
                            waitingDialog.hide();
                        }, function (reason) {
                            msg = { title: 'Error Al cargar datos del paciente' };
                            Notification.error(msg);
                            $('#collapseDataPaciente').collapse('hide');
                            waitingDialog.hide();
                        });
                    } else {
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                    };
                }, function (reason) {
                    if (reason.errorcode == 404) {
                        if (parseInt(LoginService.getTipo()) == 2) {
                            msg = { title: 'Sesion Sin Ficha, Complete la ficha para esta sesion' };
                            Notification.warning(msg);
                            fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                                $scope.Paciente = result.data;
                                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                                $scope.columnsEvolucion = [{ colId: 'col1', Fecha: '', Evolucion: '', Id: -1 }];
                                $scope.columnsMedicamentos = [{ colId: 'col1', Nombre: '', Observacion: '', Dosis: '', Horario: '', Id: -1 }];
                                $scope.columnsDiagnostico = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsIntervenciones = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1 }];
                                $scope.columnsIndicadores = [{ colId: 'col1', Tipo: { ID: '' }, Id: -1, Inicio: '', Final: '' }];
                                $scope.Ficha = { FichaEnfermeria: { Id: -1, IdReserva: sesion } };
                                $('#collapseDataPaciente').collapse('show');
                                waitingDialog.hide();
                            }, function (reason) {
                                msg = { title: 'Error Al cargar datos del paciente' };
                                Notification.error(msg);
                                $('#collapseDataPaciente').collapse('hide');
                                waitingDialog.hide();
                            });
                        } else {
                            msg = { title: 'Sesion Sin Ficha' };
                            Notification.warning(msg);
                            $('#collapseDataPaciente').collapse('hide');
                            waitingDialog.hide();
                        };
                    } else {
                        msg = { title: 'Error al Buscar Ficha' };
                        Notification.error(msg);
                        $('#collapseDataPaciente').collapse('hide');
                        waitingDialog.hide();
                    }
                });
            } else {
                $('#collapseDataPaciente').collapse('hide');
                waitingDialog.hide();
            };
        };

        $scope.SaveFicha = function () {
            if ($scope.ValidarForm()) {
                $scope.Ficha.Id = fichaService.getidFicha();
                $scope.Ficha.Fecha = moment($scope.Ficha.Fecha);
                $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria = $scope.columnsMedicamentos;
                $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria = $scope.columnsEvolucion;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico = $scope.columnsDiagnostico;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion = $scope.columnsIntervenciones;
                $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores = $scope.columnsIndicadores;
                $scope.Ficha.FichaEnfermeria.IdEspecialista = parseInt(LoginService.getIdEspecialista())
                waitingDialog.show('Guardando Ficha...', { dialogSize: 'sm' });
                fichaService.SaveFichaEnfermeria($scope.Ficha, $scope.Paciente)
                   .then(function (result) {
                       fichaService.getFichaEnfermeriaxReserva($scope.Ficha.FichaEnfermeria.IdReserva).then(function (result) {
                           $scope.Ficha = result.data;
                           $scope.columnsMedicamentos = $scope.Ficha.FichaEnfermeria.MedicamentosEnfermeria;
                           $scope.columnsEvolucion = $scope.Ficha.FichaEnfermeria.EvolucionEnfermeria;
                           for (i = 0; i < $scope.columnsEvolucion.length; i++) {
                               $scope.columnsEvolucion[i].Fecha = moment($scope.columnsEvolucion[i].Fecha);
                           }
                           $scope.columnsDiagnostico = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Diagnostico;
                           $scope.columnsIntervenciones = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Intervencion;
                           $scope.columnsIndicadores = $scope.Ficha.FichaEnfermeria.PlanEnfermeria.Indicadores;
                           $scope.Ficha.FichaEnfermeria.FechaDiagnostico = moment($scope.Ficha.FichaEnfermeria.FechaDiagnostico);
                           $scope.Ficha.FichaEnfermeria.FechaCxProced = moment($scope.Ficha.FichaEnfermeria.FechaCxProced);
                           $scope.Ficha.FichaEnfermeria.FechaAlta = moment($scope.Ficha.FichaEnfermeria.FechaAlta);
                           fichaService.getPaciente(parseInt(fichaService.getRutPaciente()), null).then(function (result) {
                               $scope.Paciente = result.data;
                               $scope.Paciente.Persona.FechaNac = moment($scope.Paciente.Persona.FechaNac);
                               msg = { title: 'Ficha guardada con éxito', message: "" };
                               Notification.success(msg);
                               waitingDialog.hide();
                               window.scrollTo(0, 0);
                           });
                       }, function (reason) {
                           msg = { title: 'Error al Intentar Recargar los datos de la Ficha guardada' };
                           Notification.error(msg);
                           $('#collapseDataPaciente').collapse('hide');
                           waitingDialog.hide();
                       });
                   }, function (reason) {
                       msg = { title: 'Error guardando Ficha' };
                       Notification.error(msg);
                       $scope.saving = false;
                       waitingDialog.hide();
                   });
            };
        }

        $scope.ValidarForm = function () {
            var error = 0;
            var msg = 'Los siguientes campos son requeridos :<br>';
            $(':input[required]', '#frmMedico').each(function () {
                $(this).css('border', '1px solid #32b8da');
                if ($(this).val() == '') {
                    msg += '<br><b>' + $(this).attr('placeholder') + '</b>';
                    $(this).css('border', '2px solid #F57E7D');
                    /*if (error == 0) {
                        $(this).focus();
                        var tab = $(this).closest('.tab-pane').attr('id');
                        $('#myTab a[href="#' + tab + '"]').tab('show');
                    }*/
                    error = 1;
                }
            });
            if (error == 1) {
                msg = { title: 'Ups, faltan campos por completar', message: msg, delay: 5000 };
                Notification.warning(msg);
                return false;
            } else {
                return true;
            }
        }
        /*Fin*/

        $scope.reporte = function (sesion) {
            url = "reports/reporte.aspx?tipo=FE&id=" + sesion
            window.open(url, '_blank');
        }
    };
}]);