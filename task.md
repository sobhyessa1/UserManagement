# gRPC Demo: User & Order Management

## Phase 1: User Management gRPC Setup (Server)
- [ ] Install `Grpc.AspNetCore` package in `UserManagement.API` <!-- id: 0 -->
- [ ] Create `Protos/user.proto` file with Service and Messages <!-- id: 1 -->
- [ ] Add `.proto` reference to `.csproj` <!-- id: 2 -->
- [ ] Implement `UserGrpcService` inheriting from generated base class <!-- id: 3 -->
- [ ] Register gRPC in `Program.cs` <!-- id: 4 -->

## Phase 2: Create Order Management Service (Client)
- [ ] Create new Solution/Projects for `OrderManagement` (Clean Architecture) <!-- id: 5 -->
- [ ] Define `Order` Entity and basic infrastructure (DbContext, Repo) <!-- id: 6 -->
- [ ] Implement `OrderService` and `OrdersController` (Basic CRUD) <!-- id: 7 -->

## Phase 3: Connect Order to User via gRPC
- [ ] Install `Grpc.Net.Client`, `Google.Protobuf`, `Grpc.Tools` in Order Management <!-- id: 8 -->
- [ ] Copy `user.proto` to Order Management <!-- id: 9 -->
- [ ] Register gRPC Client in Order Management `Program.cs` <!-- id: 10 -->
- [ ] Update `OrderService` to call `UserGrpcService` before creating an order <!-- id: 11 -->

## Phase 4: Verification
- [ ] Test creating an order for an existing user <!-- id: 12 -->
- [ ] Test creating an order for a non-existing user <!-- id: 13 -->
