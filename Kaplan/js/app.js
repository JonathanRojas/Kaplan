var app = angular.module('app',
         ['ngRoute',
          'angularModalService',
          'moment-picker',
          'ui-notification',
         'angularUtils.directives.dirPagination']
          );

app.config(function (NotificationProvider) {
    NotificationProvider.setOptions({
        delay: 3000,
        startTop: 55,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'center',
        positionY: 'top'
    });

});

app.service("ServiceObservadorUser", function () {
    this._message = [];
    function defaultReceive(message) {
        if (!this.messages) {
            this.messages = [];
        }
        this.messages.push(message);
    }

    this.listenMessage = function (sub) {
        this._message.push(sub);
        if (typeof sub.receive !== "function") {
            sub.receive = defaultReceive;
        }
    };

    this.sendMessage = function (message) {
        var len = this._message.length;
        for (var i = 0; i < len; i++) {
            this._message[i].receive(message);
        }
    };
});