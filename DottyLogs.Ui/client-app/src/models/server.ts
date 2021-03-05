export default class Server {
    tracingIdentifier: string;
    hostName: string;
    name: string;

    constructor(tracingIdentifier: string, hostName: string, name: string) {
        this.tracingIdentifier = tracingIdentifier;
        this.hostName = hostName;
        this.name = name;
    }
}