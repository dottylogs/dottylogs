export default class ServerConnectedEvent {
    traceIdentifier: string;
    hostName: string;
    applicationName: string;

    constructor(traceIdentifier: string, hostName: string, applicationName: string) {
        this.traceIdentifier = traceIdentifier;
        this.hostName = hostName;
        this.applicationName = applicationName;
    }
}