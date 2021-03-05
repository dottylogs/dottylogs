export default class ServerDisconnectedEvent {
    traceIdentifier: string;

    constructor(traceIdentifier: string) {
        this.traceIdentifier = traceIdentifier;
    }
}