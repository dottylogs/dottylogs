export default class Server {
    traceIdentifier: string;
    hostName: string;
    name: string;

    constructor(traceIdentifier: string, hostName: string, name: string) {
        this.traceIdentifier = traceIdentifier;
        this.hostName = hostName;
        this.name = name;
    }
}