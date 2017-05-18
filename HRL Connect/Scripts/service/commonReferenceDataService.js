/// <reference path="../module/hrlConnectApp.js" />
hrlConnectApp.service("operationService", function () {
    this.data = "";
    this.operationRequested = function (operation) {
        this.data = operation;
        return operation;
    }
});