export default class DottyRequest {
    requestUrl: string;
    tracingIdentifier: string;

    constructor(requestUrl: string, tracingIdentifier: string) {
        this.requestUrl = requestUrl;
        this.tracingIdentifier = tracingIdentifier;
    }
}