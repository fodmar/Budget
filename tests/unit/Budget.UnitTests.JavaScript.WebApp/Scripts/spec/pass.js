describe("mock", function () {
    var objUnderTest;

    beforeEach(function (done) {
        var stubs = {
            returnTrue: true
        };

        var context = createContext(stubs);
        context(['returnTrue'], function (mock) {
            objUnderTest = mock;
            done();
        });
    });

    it("creates mock", function () {
        expect(true).toEqual(objUnderTest);
    });
});